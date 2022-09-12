namespace CPTool.Pages.Dialogs
{
    public partial  class EquipmentTypeSubDialog
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public EquipmentTypeSubDTO Model { get; set; }
        void Submit()
        {
            if (Model.Id == 0) Model = _mapper.Map<CreateEquipmentTypeSubDTO>(Model);
            MudDialog.Close(DialogResult.Ok(Model));
        }


        void Cancel() => MudDialog.Cancel();
    }
}
