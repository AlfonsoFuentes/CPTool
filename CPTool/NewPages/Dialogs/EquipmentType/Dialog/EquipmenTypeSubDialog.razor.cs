

namespace CPTool.NewPages.Dialogs.EquipmentType.Dialog
{
    public partial class EquipmenTypeSubDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditEquipmentTypeSub Model { get; set; } = null!;
        

        [Parameter]
        public MudForm form { get; set; } = null!;


        public async virtual Task Submit()
        {
            await form.Validate();
            if (form.IsValid)
            {

                var result = await Mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();
    }
}
