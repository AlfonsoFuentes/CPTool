namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class MWOItemDialog : IDisposable
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public MWOItemDTO Model { get; set; }
        MudForm form;
        EquipmentItemPage EquipmentItemPage;
        protected override void OnInitialized()
        {

           
        }
       

        async Task Submit()
        {

            await form.Validate();
            if (form.IsValid)
            {
                if (Model.Id == 0) Model = _mapper.Map<CreateMWOItemDTO>(Model);
                MudDialog.Close(DialogResult.Ok(Model));
            }
        }


        void Cancel() => MudDialog.Cancel();

        void IDisposable.Dispose()
        {

        }
    }
}
