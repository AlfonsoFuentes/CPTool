namespace CPTool.Pages.Dialogs
{
    public partial  class EquipmentTypeSubDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public EquipmentTypeSubDTO Model { get; set; }
        void Submit()
        {
            MudDialog.Close(DialogResult.Ok(Model));
        }


        void Cancel() => MudDialog.Cancel();
    }
}
