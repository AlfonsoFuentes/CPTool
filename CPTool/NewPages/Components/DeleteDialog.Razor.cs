

using CPTool.Application.Features.Base.DeleteCommand;

namespace CPTool.NewPages.Components
{
    public partial class DeleteDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public DeleteCommand Model { get; set; } = null!;

        [Parameter]
        public string Message { get; set; } = null!;
        [Inject]
        public IMediator mediator { get; set; }

        public async  Task Submit()
        {
            
            var result = await mediator.Send(Model);

            MudDialog.Close(DialogResult.Ok(true));
        }

        void Cancel() => MudDialog.Cancel();
    }
}
