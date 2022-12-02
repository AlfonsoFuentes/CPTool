using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeatures.Query.GetById;
using CPTool.Application.Features.PurchaseOrderItemFeatures.Query.GetList;
using CPTool.Domain.Entities;

namespace CPTool.NewPages.Dialogs.PurchaseOrder.Dialog
{
    public partial class EditPurchaseOrderDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditPurchaseOrder Model { get; set; } = null!;

        EditPurchaseOrderItem SelectedItemAdded = new();

        [Parameter]
        public MudForm form { get; set; } = null!;
        String ButtonSaveName => Model.PurchaseOrderStatus == PurchaseOrderStatus.Ordering ? "Create PO" :
            Model.PurchaseOrderStatus == PurchaseOrderStatus.Created ?
            Model.pBrand.BrandType == BrandType.Brand ? "Receive PO" : "Install PO" :
            Model.PurchaseOrderStatus == PurchaseOrderStatus.Received ? "Install PO" : "Close";
        protected override void OnInitialized()
        {
            Model.POEstimatedDate = Model.PurchaseOrderStatus == PurchaseOrderStatus.Ordering ? DateTime.Now : Model.POEstimatedDate;
        }

        async Task ValidateForm()
        {
            await form.Validate();
        }

        public async virtual Task Submit()
        {
            await ValidateForm();
            if (form.IsValid)
            {

                if (Model.PurchaseOrderStatus == PurchaseOrderStatus.Ordering)
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
                await Mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();
        private string ValidatePONumber(string arg)
        {


            if (arg == "")
                return "Must define PO number";
            if (!arg.StartsWith("850"))
                return "PO number must start with 850";
            if (arg.Length != 10)
                return "PO number must have ten numbers";
            if (Model.PurchaseOrderStatus == PurchaseOrderStatus.Ordering)
            {
                if (GlobalTables.PurchaseOrders.Any(x => x.Id != Model.Id && x.PONumber == arg))
                {
                    return "PO number existing";
                }
            }

            return null;

        }
        //string ValidateDate(DateTime time)
        //{
        //    if (time.Date < DateTime.Today)
        //    {
        //        return $"Must Select date greater than {DateTime.Today}";
        //    }
        //    return null;
        //}
        async Task ChangeMWOItem()
        {


            var result = await ToolDialogService.ShowChangePurchaseOrderMWOItem(SelectedItemAdded);
            if (!result.Cancelled)
            {
                GetPurchaseOrderItemListQuery getPurchaseOrderItem = new();
                GlobalTables.PurchaseOrderItems = await Mediator.Send(getPurchaseOrderItem);

                GetPurchaseOrderListQuery getPurchaseOrderListQuery = new();
                GlobalTables.PurchaseOrders = await Mediator.Send(getPurchaseOrderListQuery);

                GetMWOItemListQuery getMWOItemListQuery = new();
                GlobalTables.MWOItems = await Mediator.Send(getMWOItemListQuery);

                GetByIdPurchaseOrderItemQuery getByIdPurchaseOrderItemQuery = new() { Id = SelectedItemAdded.Id };
                SelectedItemAdded = await Mediator.Send(getByIdPurchaseOrderItemQuery);

                GetByIdPurchaseOrderQuery getByIdPurchaseOrderQuery = new() { Id = Model.Id };
                Model = await Mediator.Send(getByIdPurchaseOrderQuery);

            }
        }
    }
}
