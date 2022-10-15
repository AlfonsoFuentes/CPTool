

namespace CPTool.NewPages.Dialogs.EquipmentType.Dialog
{
    public partial class EquipmenTypeDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditEquipmentType Model { get; set; } = null!;
        [Inject]
        public IMediator mediator { get; set; }

        [Parameter]
        public MudForm form { get; set; } = null!;


        public async virtual Task Submit()
        {
            await form.Validate();
            if (form.IsValid)
            {

                var result = await mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();
    }
}
