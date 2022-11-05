using CPTool.Application.Features.SignalsFeatures.CreateEdit;


namespace CPTool.NewPages.Dialogs.Signal.Dialog
{
    public partial class SignalDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditSignal Model { get; set; } = null!;



        [Parameter]
        public MudForm form { get; set; } = null!;

        async Task ValidateForm()
        {
            await form.Validate();
        }

        public async virtual Task Submit()
        {
            await ValidateForm();
            if (form.IsValid)
            {

                await Mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();

       
    }
}
