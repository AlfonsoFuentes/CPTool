using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CPTool.NewPages.Dialogs.PurchaseOrder.Dialog
{
    public partial class ChangePurchaserItemMWOItemDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditPurchaseOrderItem Model { get; set; } = null!;

        EditMWOItem NewMWOItem = new();

        [Parameter]
        public MudForm form { get; set; } = null!;

        async Task ValidateForm()
        {
            await form.Validate();
        }
        List<EditMWOItem> MWOItems=>GlobalTables.MWOItems.Where(x=>x.MWOId==Model.MWOItem.MWOId&&x.Id!= Model.MWOItem.Id).ToList();
        public async virtual Task Submit()
        {
            await ValidateForm();
            if (form.IsValid)
            {
                Model.MWOItem = NewMWOItem;
                await Mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }
        void Cancel() => MudDialog.Cancel();
    }
}
