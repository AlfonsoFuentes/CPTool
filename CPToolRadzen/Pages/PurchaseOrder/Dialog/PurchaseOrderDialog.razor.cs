using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using CPTool.Domain.Entities;
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
        List<EditMWOItem> EditMWOItemsOriginal = new();

        string ButtonName { get => GetButtonName(); set => base.SaveButtonName = value; }
        bool DisableSave { get => OnDisableButtonSave(); set => base.DisableButtonSave = value; }
        protected override void OnInitialized()
        {
            FilteredList = Model.Id == 0 ? RadzenTables.PurchaseOrders : RadzenTables.PurchaseOrders.Where(x => x.Id != Model.Id).ToList();
            Model.POEstimatedDate = Model.PurchaseOrderStatus == PurchaseOrderStatus.Ordering ? DateTime.UtcNow : Model.POReceivedDate;
            Model.USDCOP = Model.Id==0? _CurrencyService.RateList == null ? 4900 : Math.Round(_CurrencyService.RateList["COP"], 2) : Model.USDCOP;
            Model.USDEUR = Model.Id == 0 ? _CurrencyService.RateList == null ? 1 : Math.Round(_CurrencyService.RateList["EUR"], 2): Model.USDEUR;
            EditMWOItemsOriginal = RadzenTables.MWOItems.Where(x => x.MWOId == Model.MWOId).ToList(); 
        }
        string GetButtonName()
        {
           return Model.Id == 0 ? "Create PR" : Model.PurchaseOrderStatus == PurchaseOrderStatus.Ordering ? "Create PO" :
           Model.PurchaseOrderStatus == PurchaseOrderStatus.Created ?
           Model.pBrand.BrandType == BrandType.Brand ? "Receive PO" : "Install PO" :
           Model.PurchaseOrderStatus == PurchaseOrderStatus.Received ? "Install PO" : "Close";
        }
        bool OnDisableButtonSave()
        {
            if (Model.Id == 0 && Model.PurchaseOrderItems.Count == 0) return true;

            if (Model.PurchaseOrderStatus == PurchaseOrderStatus.Received) return true;

            return false;
        }
        bool InlineEdit => DisableAddRemoveMWOItem;
        bool DisableAddRemoveMWOItem => OnDisableAddRemoveMWOItem();
        bool OnDisableAddRemoveMWOItem()
        {
            if (Model.Id == 0 && Model.pSupplier.Id != 0 && SelectedItemToAdd.Id != 0
                                                    && Model.Currency != Currency.None) return false;
            return true;
        }
        protected  async Task SavePurchaseOrder()
        {
            if (SaveDialog)
            {
                if (Model.PurchaseOrderStatus == PurchaseOrderStatus.Draft)
                {
                    Model.POOrderingdDate = DateTime.UtcNow;
                    Model.PurchaseOrderStatus = CPTool.Domain.Entities.PurchaseOrderStatus.Ordering;
                    Model.CurrencyDate = DateTime.UtcNow;
                }

                else if (Model.PurchaseOrderStatus == PurchaseOrderStatus.Ordering)
                {
                    Model.POCreatedDate = DateTime.Now;
                    Model.PurchaseOrderStatus = PurchaseOrderStatus.Created;
                }
                else if (Model.PurchaseOrderStatus == PurchaseOrderStatus.Created)
                {
                    if (Model.pBrand.BrandType == BrandType.Brand)
                    {
                        Model.POReceivedDate = DateTime.Now;
                        Model.PurchaseOrderStatus = PurchaseOrderStatus.Received;
                    }
                    else
                    {
                        Model.POReceivedDate = DateTime.Now;
                        Model.PurchaseOrderStatus = PurchaseOrderStatus.Installed;
                        Model.POInstalledDate = DateTime.Now;
                    }

                }
                else if (Model.PurchaseOrderStatus == PurchaseOrderStatus.Received)
                {
                    Model.POInstalledDate = DateTime.Now;
                    Model.PurchaseOrderStatus = PurchaseOrderStatus.Installed;
                }
                else if (Model.PurchaseOrderStatus == PurchaseOrderStatus.Installed)
                {

                    Model.PurchaseOrderStatus = PurchaseOrderStatus.Closed;
                }
               
                var result = await CommandQuery.AddUpdate(Model);

                DialogService.Close(result.Succeeded);
            }
            else
            {
                DialogService.Close(true);
            }

        }
        EditMWOItem SelectedItemToAdd = new();
        EditPurchaseOrderItem SelectedItemAdded = new();
        private async Task AddItem()
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

            Model.MWOItem = MWOItem;
            if (await DialogService.Confirm($"Are you sure you want to add {MWOItem.Name} to Purchase order item list?") == true)
            {


                Model.PurchaseOrderItems.Add(purchaseOrderItem);
                EditMWOItemsOriginal.Remove(SelectedItemToAdd);
                Model.PurchaseOrderItems = Model.PurchaseOrderItems.OrderBy(x => x.MWOItem!.Nomenclatore).ToList();
                EditMWOItemsOriginal = EditMWOItemsOriginal.OrderBy(x => x.Nomenclatore).ToList();
                SelectedItemToAdd = new();
                SelectedItemAdded = new();
            }



        }
       
        private void RemoveItem()
        {

            var selected = Model.PurchaseOrderItems.FirstOrDefault(x => x.MWOItemId == SelectedItemAdded.MWOItem.Id);
            Model.PurchaseOrderItems.Remove(selected);
            EditMWOItemsOriginal.Add(SelectedItemAdded.MWOItem);
            Model.PurchaseOrderItems = Model.PurchaseOrderItems.OrderBy(x => x.MWOItem!.Nomenclatore).ToList();

            EditMWOItemsOriginal = EditMWOItemsOriginal.OrderBy(x => x.Nomenclatore).ToList();
            SelectedItemToAdd = new();
            SelectedItemAdded = new();
        }
    }
}