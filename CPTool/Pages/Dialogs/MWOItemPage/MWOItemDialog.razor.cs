namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class MWOItemDialog : IDisposable
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public MWOItemDTO Model { get; set; }
        public MudForm form;
        EquipmentItemPage EquipmentItemPage;
        protected override void OnInitialized()
        {

          


        }
        protected override void OnAfterRender(bool firstRender)
        {
            if(firstRender)
            {
                ViewSpecificSpec();
            }
            base.OnAfterRender(firstRender);
        }
        void ViewSpecificSpec()
        {
            ViewSpecs();
            StateHasChanged();
            
            switch (Model.ChapterId)
            {
                case 4:
                    bEquipmentVisible = true;
                    TablesService.ManMWOItem.PriorSave += EquipmentItemPage.OnSave;
                    break;
            }
            ViewName();
            StateHasChanged();
        }

        async Task Submit()
        {

            await form.Validate();
            if (form.IsValid)
            {

                MudDialog.Close(DialogResult.Ok(Model));
            }
        }

        public void GetSaveEvent()
        {

            ViewSpecificSpec();
        }

        void Cancel() => MudDialog.Cancel();
        bool bEquipmentVisible = false;
        bool bViewSpecs = false;
        bool bViewName = true;
        void ViewName()
        {
            bViewName = true;
            bViewSpecs = !bViewName;
        }
        void ViewSpecs()
        {
            bViewSpecs = true;
            bViewName = !bViewSpecs;
        }
        void IDisposable.Dispose()
        {
            if (TablesService.ManMWOItem.PriorSave != null)
            {
                if (Model.ChapterDTO.Id == 4)
                {

                    TablesService.ManMWOItem.PriorSave -= EquipmentItemPage.OnSave;
                }
            }
        }
    }
}
