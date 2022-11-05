using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Domain.Entities;

namespace CPTool.NewPages.Dialogs.PurchaseOrder.Dialog
{
    public partial class EditPurchaseOrderDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditPurchaseOrder Model { get; set; } = null!;

       

        [Parameter]
        public MudForm form { get; set; } = null!;
        String ButtonSaveName => Model.PurchaseOrderStatus == PurchaseOrderStatus.Ordering ? "Create PO" :
            Model.PurchaseOrderStatus == PurchaseOrderStatus.Created ? "Receive PO" :
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
                }
                else if (Model.PurchaseOrderStatus == PurchaseOrderStatus.Created)
                {
                    Model.POReceivedDate = DateTime.Now;
                }
                else if (Model.PurchaseOrderStatus == PurchaseOrderStatus.Received)
                {
                    Model.POInstalledDate = DateTime.Now;
                }
                Model.PurchaseOrderStatus = Model.PurchaseOrderStatus == PurchaseOrderStatus.Ordering ? PurchaseOrderStatus.Created :
Model.PurchaseOrderStatus == PurchaseOrderStatus.Created ? PurchaseOrderStatus.Received : PurchaseOrderStatus.Installed;
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
            if (Model.PurchaseOrderStatus==PurchaseOrderStatus.Ordering&& GlobalTables.PurchaseOrders.Any(x => x.PONumber == arg))
                return "PO number existing";
            return null;

        }
        string ValidateDate(DateTime time)
        {
            if (time.Date < DateTime.Today)
            {
                return $"Must Select date greater than {DateTime.Today}";
            }
            return null;
        }
    }
}
