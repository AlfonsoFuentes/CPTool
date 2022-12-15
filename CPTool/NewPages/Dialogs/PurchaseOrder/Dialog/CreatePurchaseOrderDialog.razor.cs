

using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.ProcessFluidFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using CPTool.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace CPTool.NewPages.Dialogs.PurchaseOrder.Dialog
{
    public partial class CreatePurchaseOrderDialog
    {
        [Inject]
        public ICurrencyApi _CurrencyService { get; set; }
        List<EditMWOItem> EditMWOItemsOriginal = new();
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditPurchaseOrder Model { get; set; } = null!;
       
        protected override void OnInitialized()
        {
            Model.USDCOP = _CurrencyService.RateList == null ? 4900 : Math.Round(_CurrencyService.RateList["COP"], 2);
            Model.USDEUR = _CurrencyService.RateList == null ? 1 : Math.Round(_CurrencyService.RateList["EUR"], 2);
            EditMWOItemsOriginal = GlobalTables.MWOItems.Where(x => x.MWOId == Model.MWOId).ToList(); ;
        }
        [Parameter]
        public MudForm form { get; set; } = null!;
        private string ValidateCurrency(Currency arg)
        {
            if (arg == Currency.None)
                return "Must submit Currency";


            return null;
        }
        async Task ValidateForm()
        {
            await form.Validate();
        }
        bool DisableButton => OnDisableButton();
        bool OnDisableButton()
        {
            if (Model.PurchaseOrderItems.Count == 0) return true;
            return false;
        }

        public async virtual Task Submit()
        {
            await ValidateForm();
            if (form.IsValid)
            {
                Model.POOrderingdDate = DateTime.UtcNow;
                Model.PurchaseOrderStatus = Domain.Entities.PurchaseOrderStatus.Ordering;
                Model.CurrencyDate = DateTime.UtcNow;
                await Mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();

        private string ValidatePurchaseOrderName(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Purchase Order name";

            return null;
        }
        private string ValidatePurchaseRequisition(string arg)
        {
            if (arg == null || arg == "")
                return "Must submit Purchase Requistion Name";
            if (GlobalTables.PurchaseOrders.Any(x => x.PurchaseRequisition == arg))
            {
                return "Existing Purchase Requistion ";
            }
            if (arg.StartsWith("PR") || arg.StartsWith("RFQ"))
                return null;
            else
                return "Must submit Valid code PR or RFQ";


        }
        private string ValidateBrand(int arg)
        {
            if (arg == 0)
                return "Must submit Brand";

            return null;

        }

        private string ValidateSupplier(int arg)
        {
            if (arg == 0)
                return "Must submit Supplier";

            return null;

        }
        void BrandChanged(EditBrand brand)
        {

            Model.pSupplier = new();
            StateHasChanged();
        }
        EditMWOItem SelectedItemToAdd = new();
        EditPurchaseOrderItem SelectedItemAdded = new();
        private async Task AddItem()
        {


            var MWOItem = SelectedItemToAdd;

            Model.TaxCode = Model.TaxCode == "" ?
                MWOItem.ChapterId == 1 ?
                Model.pSupplier!.TaxCodeLP!.Name : Model.pSupplier!.TaxCodeLD!.Name : Model.TaxCode;
            Model.SPL = Model.SPL == "" ? MWOItem.ChapterId == 1 ? "0735015000" : "151605000" : Model.  SPL;
            Model.CostCenter = MWOItem!.ChapterId! == 1 ? MWOItem!.AlterationItem!.CostCenter! : "";
            EditPurchaseOrderItem purchaseOrderItem = new();
            purchaseOrderItem.MWOItem = MWOItem;
            purchaseOrderItem.PurchaseOrder = Model;

            Model.MWOItem = MWOItem;
            var result = await ToolDialogService.ShowAddDataToPurchaseOrderDialog(purchaseOrderItem);
            if (!result.Cancelled)
            {
                var retorno = result.Data as EditPurchaseOrderItem;

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

            var selected = Model.PurchaseOrderItems.FirstOrDefault(x => x.MWOItemId == SelectedItemAdded.Id);
            Model.PurchaseOrderItems.Remove(selected);
            EditMWOItemsOriginal.Add(SelectedItemAdded.MWOItem);
            Model.PurchaseOrderItems = Model.PurchaseOrderItems.OrderBy(x => x.MWOItem!.Nomenclatore).ToList();

            EditMWOItemsOriginal = EditMWOItemsOriginal.OrderBy(x => x.Nomenclatore).ToList();
            SelectedItemToAdd = new();
            SelectedItemAdded = new();
        }

    }
}