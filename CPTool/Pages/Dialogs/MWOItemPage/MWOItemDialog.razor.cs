using System.Security.Cryptography;

namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class MWOItemDialog : IDisposable
    {
       

        [Parameter]
        public MWOItemDTO Model { get; set; }
      
         async Task OnInit()
        {
            ChapterChange();

          
            await Task.CompletedTask;
        }
        public void ChapterChange()
        {
       
            switch (Model.ChapterId)
            {
                case 4:
                   
                   
                    TablesService.ManMWOItem.PriorSave += OnSaveEquipment;
                    break;
            }
      
      
        }
        bool bViewName = true;
        bool bViewSpecs = false;
        void ViewName()
        {
            bViewName = true;
            bViewSpecs = false;
        }
        void ViewSpecs()
        {
            bViewName = false;
            bViewSpecs = true;
        }
        void IDisposable.Dispose()
        {
            if (TablesService.ManMWOItem.PriorSave != null)
            {
                if (Model.ChapterDTO.Id == 4)
                {

                    TablesService.ManMWOItem.PriorSave -= OnSaveEquipment;
                }
            }
        }
        public async Task<IResult<IAuditableEntityDTO>> OnSaveEquipment(IAuditableEntityDTO dto)
        {


            var result = await TablesService.ManItemEquipment.AddUpdate(Model.EquipmentItemDTO, _cts.Token);
            if (result.Succeeded)
            {
                (dto as MWOItemDTO).EquipmentItemDTO = result.Data;
                return await Result<IAuditableEntityDTO>.SuccessAsync((dto as MWOItemDTO), "Updated");
            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not created!");
        }
    }
}
