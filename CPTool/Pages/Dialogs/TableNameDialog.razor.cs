


namespace CPTool.Pages.Dialogs
{
    public partial class TableNameDialog<T> where T : IAuditableEntityDTO, new()
    {

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public T Model { get; set; }
        void Submit()
        {
            MudDialog.Close(DialogResult.Ok(Model));
        }


        void Cancel() => MudDialog.Cancel();

    }
}
