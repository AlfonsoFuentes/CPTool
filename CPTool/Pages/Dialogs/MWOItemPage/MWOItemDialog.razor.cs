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
                    TablesService.ManEquipmentItem.PriorSave += OnSaveMaterialEquipment;
                    break;
                case 7:
                    TablesService.ManMWOItem.PriorSave += OnSaveInstrument;
                    TablesService.ManInstrumentItem.PriorSave += OnSaveMaterialInstrument;
                    break;
            }
           StateHasChanged();

        }
        bool bViewName = true;
        bool bViewSpecs = false;
        bool bViewMaterials = false;
        void ViewName()
        {
            bViewName = true;
            bViewSpecs = false;
            bViewMaterials = false;
        }
        void ViewSpecs()
        {
            bViewName = false;
            bViewSpecs = true;
            bViewMaterials = false;
        }
        void ViewMaterials()
        {
            bViewName = false;
            bViewSpecs = false;
            bViewMaterials = true;
        }
        void IDisposable.Dispose()
        {
            if (TablesService.ManMWOItem.PriorSave != null)
            {
                switch (Model.ChapterId)
                {
                    case 4:
                        TablesService.ManMWOItem.PriorSave -= OnSaveEquipment;
                        TablesService.ManEquipmentItem.PriorSave -= OnSaveMaterialEquipment;
                        break;
                    case 7:
                        TablesService.ManMWOItem.PriorSave -= OnSaveInstrument;
                        TablesService.ManInstrumentItem.PriorSave -= OnSaveMaterialInstrument;
                        break;
                }
            }
        }
        public async Task<IResult<IAuditableEntityDTO>> OnSaveEquipment(IAuditableEntityDTO dto)
        {


            var result = await TablesService.ManEquipmentItem.AddUpdate(Model.EquipmentItemDTO, _cts.Token);
            if (result.Succeeded)
            {
                (dto as MWOItemDTO).EquipmentItemDTO = result.Data;
                return await Result<IAuditableEntityDTO>.SuccessAsync((dto as MWOItemDTO), "Updated");
            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not created!");
        }
        public async Task<IResult<IAuditableEntityDTO>> OnSaveInstrument(IAuditableEntityDTO dto)
        {


            var result = await TablesService.ManInstrumentItem.AddUpdate(Model.InstrumentItemDTO, _cts.Token);
            if (result.Succeeded)
            {
                (dto as MWOItemDTO).InstrumentItemDTO = result.Data;
                return await Result<IAuditableEntityDTO>.SuccessAsync((dto as MWOItemDTO), "Updated");
            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not created!");
        }
        public async Task<IResult<IAuditableEntityDTO>> OnSaveMaterialInstrument(IAuditableEntityDTO dto)
        {


            var result = await TablesService.ManMaterialsGroup.AddUpdate(Model.InstrumentItemDTO.MaterialsGroupDTO, _cts.Token);
            if (result.Succeeded)
            {
                (dto as InstrumentItemDTO).MaterialsGroupDTO = result.Data;
                return await Result<IAuditableEntityDTO>.SuccessAsync((dto as InstrumentItemDTO), "Updated");
            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not created!");
        }
        public async Task<IResult<IAuditableEntityDTO>> OnSaveMaterialEquipment(IAuditableEntityDTO dto)
        {


            var result = await TablesService.ManMaterialsGroup.AddUpdate(Model.EquipmentItemDTO.MaterialsGroupDTO, _cts.Token);
            if (result.Succeeded)
            {
                (dto as EquipmentItemDTO).MaterialsGroupDTO = result.Data;
                return await Result<IAuditableEntityDTO>.SuccessAsync((dto as EquipmentItemDTO), "Updated");
            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not created!");
        }
    }
}
