

using CPTool.Application.Features.Base.Delete;

namespace CPTool.NewPages.Components.Dialogs
{
    public partial class DeleteDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; } = null!;
        [Parameter]
        public DeleteCommand Model { get; set; } = null!;

        [Parameter]
        public string Message { get; set; } = null!;
        

        public async  Task Submit()
        {
            
            var result = await Mediator.Send(Model);

            MudDialog.Close(DialogResult.Ok(true));
        }

        void Cancel() => MudDialog.Cancel();
    }
}
