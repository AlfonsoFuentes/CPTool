namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class MWOItemDialog : IDisposable
    {
       

        [Parameter]
        public MWOItemDTO Model { get; set; }
      
        EquipmentItemPage EquipmentItemPage;
        
       
        bool bViewButtonSpecs = false;
        void ViewSpecificSpec()
        {
            ViewSpecs();
            StateHasChanged();
            
            switch (Model.ChapterId)
            {
                case 4:
                    bEquipmentVisible = true;
                    bViewButtonSpecs = true;
                    TablesService.ManMWOItem.PriorSave += EquipmentItemPage.OnSave;
                    break;
            }
            ViewName();
            StateHasChanged();
        }

       

        public void GetSaveEvent()
        {

            ViewSpecificSpec();
        }

      
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
