using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using CPTool.Domain.Enums;
using CPTool.Services;
using CPToolRadzen.Pages.MWOItems.Dialog;
using CPToolRadzen.Services;
using Microsoft.AspNetCore.Components;

namespace CPToolRadzen.Pages.PurchaseOrder.Dialog
{
    public partial class PurchaseOrderDialog : DialogTemplate<EditPurchaseOrder>
    {
        [Inject]
        public ICurrencyApi _CurrencyService { get; set; }
        public List<EditMWOItem> MWOItemsOriginal = new();

        string ButtonName { get => GetButtonName(); set => base.SaveButtonName = value; }
        bool DisableSave { get => OnDisableButtonSave(); set => base.DisableButtonSave = value; }
        protected override async Task OnInitializedAsync()
        {
            Model = await CommandQuery.GetById(Model.Id);
            FilteredList = await CommandQuery.GetAll();
            FilteredList = Model.Id == 0 ? FilteredList : FilteredList.Where(x => x.Id != Model.Id).ToList();
            RadzenTables.Brands = await QueryBrand.GetAll();
            RadzenTables.BrandSuppliers = await QueryBrandSupplier.GetAll();
            RadzenTables.MWOItems = await QueryMWOItem.GetAll();
            Model.POEstimatedDate = Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Ordering ? DateTime.UtcNow : Model.POReceivedDate;
            Model.USDCOP = Model.Id==0? _CurrencyService.RateList == null ? 4900 : Math.Round(_CurrencyService.RateList["COP"], 2) : Model.USDCOP;
            Model.USDEUR = Model.Id == 0 ? _CurrencyService.RateList == null ? 1 : Math.Round(_CurrencyService.RateList["EUR"], 2): Model.USDEUR;
            MWOItemsOriginal = RadzenTables.MWOItems.Where(x => x.MWOId == Model.MWOId).ToList();
            
        }
        string GetButtonName()
        {
           return Model.Id == 0 ? "Create PR" : Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Ordering ? "Create PO" :
           Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Created ?
           Model.pBrand.BrandType == BrandType.Brand ? "Receive PO" : "Install PO" :
           Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Received ? "Install PO" : "Close";
        }
        bool OnDisableButtonSave()
        {
            if (Model.Id == 0 && Model.PurchaseOrderItems.Count == 0) return true;

            if (Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Received) return true;

            return false;
        }
       public bool InlineEdit => DisableAddRemoveMWOItem;
       public bool DisableAddRemoveMWOItem => OnDisableAddRemoveMWOItem();
        bool OnDisableAddRemoveMWOItem()
        {
            if (Model.pSupplier.Id != 0 && SelectedItemToAdd.Id != 0
                                                    && Model.Currency != Currency.None) return false;
            return true;
        }
        protected  async Task SavePurchaseOrder()
        {
            if (SaveDialog)
            {
                if (Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Draft)
                {
                    Model.POOrderingdDate = DateTime.UtcNow;
                    Model.PurchaseOrderStatus = PurchaseOrderApprovalStatus.Ordering;
                    Model.CurrencyDate = DateTime.UtcNow;
                }

                else if (Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Ordering)
                {
                    Model.POCreatedDate = DateTime.Now;
                    Model.PurchaseOrderStatus = PurchaseOrderApprovalStatus.Created;
                }
                else if (Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Created)
                {
                    if (Model.pBrand.BrandType == BrandType.Brand)
                    {
                        Model.POReceivedDate = DateTime.Now;
                        Model.PurchaseOrderStatus = PurchaseOrderApprovalStatus.Received;
                    }
                    else
                    {
                        Model.POReceivedDate = DateTime.Now;
                        Model.PurchaseOrderStatus = PurchaseOrderApprovalStatus.Installed;
                        Model.POInstalledDate = DateTime.Now;
                    }

                }
                else if (Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Received)
                {
                    Model.POInstalledDate = DateTime.Now;
                    Model.PurchaseOrderStatus = PurchaseOrderApprovalStatus.Installed;
                }
                else if (Model.PurchaseOrderStatus == PurchaseOrderApprovalStatus.Installed)
                {

                    Model.PurchaseOrderStatus = PurchaseOrderApprovalStatus.Closed;
                }
               
                var result = await CommandQuery.AddUpdate(Model);

                DialogService.Close(result.Succeeded);
            }
            else
            {
                DialogService.Close(true);
            }

        }
        public EditMWOItem SelectedItemToAdd = new();
        public EditPurchaseOrderItem SelectedItemAdded = new();
        public async Task AddItem()
        {


            var MWOItem = SelectedItemToAdd;

            Model.TaxCode = Model.TaxCode == "" ?
                MWOItem.ChapterId == 1 ?
                Model.pSupplier!.TaxCodeLP!.Name : Model.pSupplier!.TaxCodeLD!.Name : Model.TaxCode;
            Model.SPL = Model.SPL == "" ? MWOItem.ChapterId == 1 ? "0735015000" : "151605000" : Model.SPL;
            Model.CostCenter = MWOItem!.ChapterId! == 1 ? MWOItem!.AlterationItem!.CostCenter! : "";
            EditPurchaseOrderItem purchaseOrderItem = new();
            purchaseOrderItem.MWOItem = MWOItem;
            purchaseOrderItem.PurchaseOrder = Model;

         
            if (await DialogService.Confirm($"Are you sure you want to add {MWOItem.Name} to Purchase order item list?") == true)
            {


                Model.PurchaseOrderItems.Add(purchaseOrderItem);
                MWOItemsOriginal.Remove(SelectedItemToAdd);
                Model.PurchaseOrderItems = Model.PurchaseOrderItems.OrderBy(x => x.MWOItem!.Nomenclatore).ToList();
              
                SelectedItemToAdd = new();
                SelectedItemAdded = new();
            }



        }
       
        public void RemoveItem()
        {

            var selected = Model.PurchaseOrderItems.FirstOrDefault(x => x.MWOItemId == SelectedItemAdded.MWOItem.Id);
            Model.PurchaseOrderItems.Remove(selected);
            MWOItemsOriginal.Add(SelectedItemAdded.MWOItem);
            Model.PurchaseOrderItems = Model.PurchaseOrderItems.OrderBy(x => x.MWOItem!.Nomenclatore).ToList();
            StateHasChanged();
            StateHasChanged();

            SelectedItemToAdd = new();
            SelectedItemAdded = new();
        }
    }
}