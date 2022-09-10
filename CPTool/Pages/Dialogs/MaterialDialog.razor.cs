namespace CPTool.Pages.Dialogs
{
    public partial  class MaterialDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public MaterialDTO Model { get; set; }
        void Submit()
        {
            MudDialog.Close(DialogResult.Ok(Model));
        }


        void Cancel() => MudDialog.Cancel();
    }
}
