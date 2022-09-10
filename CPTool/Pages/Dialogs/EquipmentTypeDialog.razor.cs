namespace CPTool.Pages.Dialogs
{
    public partial  class EquipmentTypeDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public EquipmentTypeDTO Model { get; set; }
        void Submit()
        {
            MudDialog.Close(DialogResult.Ok(Model));
        }


        void Cancel() => MudDialog.Cancel();
    }
}
