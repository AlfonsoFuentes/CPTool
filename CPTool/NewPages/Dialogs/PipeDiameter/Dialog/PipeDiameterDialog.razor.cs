using CPTool.Application.Features.NozzleFeatures.CreateEdit;
using CPTool.Application.Features.PipeDiameterFeatures.CreateEdit;

namespace CPTool.NewPages.Dialogs.PipeDiameter.Dialog
{
    public partial class PipeDiameterDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public EditPipeDiameter Model { get; set; } = null!;



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

                var result = await mediator.Send(Model);

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        void Cancel() => MudDialog.Cancel();

       
    }
}
