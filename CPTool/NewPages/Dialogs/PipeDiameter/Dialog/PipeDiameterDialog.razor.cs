using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.Command.CreateEdit;

namespace CPTool.NewPages.Dialogs.PipeDiameter.Dialog
{
    public partial class PipeDiameterDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public AddEditPipeDiameterCommand Model { get; set; } = null!;



        [Inject]
        public IMediator mediator { get; set; }

        [Parameter]
        public MudForm form { get; set; } = null!;

        async Task ValidateForm()
        {
            await form.Validate();
            StateHasChanged();
        }

        public async virtual Task Submit()
        {
            await ValidateForm();
            if (form.IsValid)
            {



                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();

       
    }
}
