using CPtool.ExtensionMethods;
using System.Security.Cryptography;

namespace CPTool.Pages.Dialogs.MWOItemPage
{
    public partial class MWOItemDialog : IDisposable
    {
        [CascadingParameter]
        public ComponentBaseDialog<MWOItemDTO> basedialog { get; set; }

        [Parameter]
        public MWOItemDTO Model { get; set; }

        //[Inject]
        //public ICreationMethod<EquipmentItemDTO, EquipmentItem> createequipmentItem { get; set; }

        async Task OnInit()
        {
            ChapterChange();


            await Task.CompletedTask;
        }
        public void ChapterChange()
        {

            switch (Model.ChapterDTO?.Id)
            {
                case 4:
                   
                    Model.EquipmentItemDTO = Model.EquipmentItemDTO == null ? new(): Model.EquipmentItemDTO;
                    
                    break;
                case 6:
                    Model.PipingItemDTO = Model.PipingItemDTO == null ? new() : Model.PipingItemDTO;
                    break;
                case 7:
                    Model.InstrumentItemDTO = Model.InstrumentItemDTO == null ? new() : Model.InstrumentItemDTO;
                   
            
                    break;
            }
            StateHasChanged();

        }
        bool bViewName = true;
        bool bViewSpecs = false;
        bool bViewMaterials = false;
        bool bNozzles = false;
        void ViewName()
        {
            bViewName = true;
            bViewSpecs = false;
            bViewMaterials = false;
            bNozzles = false;
        }
        void ViewSpecs()
        {
            bViewName = false;
            bViewSpecs = true;
            bViewMaterials = false;
            bNozzles = false;
        }
        void ViewMaterials()
        {
            bViewName = false;
            bViewSpecs = false;
            bViewMaterials = true;
            bNozzles = false;
        }
        void ViewNozzles()
        {
            bViewName = false;
            bViewSpecs = false;
            bViewMaterials = false;
            bNozzles = true;
        }
        void IDisposable.Dispose()
        {
            if (TablesService.ManMWOItem.PriorSave != null)
            {
                switch (Model.ChapterDTO?.Id)
                {
                    case 4:
                        TablesService.ManMWOItem.PriorSave -= OnSaveEquipment;
                        TablesService.ManEquipmentItem.PriorSave -= OnSaveProcessConditionEquipment;
                        TablesService.ManProcessCondition.PriorSave -= OnSaveUnitsProcessConditionEquipment;
                        break;
                    case 7:
                        TablesService.ManMWOItem.PriorSave -= OnSaveInstrument;
                        TablesService.ManInstrumentItem.PriorSave -= OnSaveProcessConditionInstrument;
                        TablesService.ManProcessCondition.PriorSave -= OnSaveUnitsProcessConditionInstrument;
                        break;
                }
            }
        }
        public async Task<IResult<IAuditableEntityDTO>> OnSaveEquipment(IAuditableEntityDTO dto)
        {


            var result = await TablesService.ManEquipmentItem.AddUpdate(Model.EquipmentItemDTO, _cts.Token);
            if (result.Succeeded)
            {
                (dto as MWOItemDTO).EquipmentItemDTO = result.Data as EquipmentItemDTO;
                return await Result<IAuditableEntityDTO>.SuccessAsync((dto as MWOItemDTO), "Updated");
            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not created!");
        }
        public async Task<IResult<IAuditableEntityDTO>> OnSavePiping(IAuditableEntityDTO dto)
        {


            var result = await TablesService.ManPipingItem.AddUpdate(Model.PipingItemDTO, _cts.Token);
            if (result.Succeeded)
            {
                (dto as MWOItemDTO).PipingItemDTO = result.Data as PipingItemDTO;
                return await Result<IAuditableEntityDTO>.SuccessAsync((dto as MWOItemDTO), "Updated");
            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not created!");
        }
        public async Task<IResult<IAuditableEntityDTO>> OnSaveInstrument(IAuditableEntityDTO dto)
        {


            var result = await TablesService.ManInstrumentItem.AddUpdate(Model.InstrumentItemDTO, _cts.Token);
            if (result.Succeeded)
            {
                (dto as MWOItemDTO).InstrumentItemDTO = result.Data as InstrumentItemDTO;
                return await Result<IAuditableEntityDTO>.SuccessAsync((dto as MWOItemDTO), "Updated");
            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not created!");
        }
        public async Task<IResult<IAuditableEntityDTO>> OnSaveProcessConditionEquipment(IAuditableEntityDTO dto)
        {


            var result = await TablesService.ManProcessCondition.AddUpdate(Model.EquipmentItemDTO.ProcessConditionDTO, _cts.Token);
            if (result.Succeeded)
            {
                (dto as EquipmentItemDTO).ProcessConditionDTO = result.Data as ProcessConditionDTO;
                return await Result<IAuditableEntityDTO>.SuccessAsync((dto as EquipmentItemDTO), "Updated");
            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not created!");
        }
        public async Task<IResult<IAuditableEntityDTO>> OnSaveProcessConditionInstrument(IAuditableEntityDTO dto)
        {
            var result = await TablesService.ManProcessCondition.AddUpdate(Model.InstrumentItemDTO.ProcessConditionDTO, _cts.Token);
            if (result.Succeeded)
            {
                (dto as InstrumentItemDTO).ProcessConditionDTO = result.Data as ProcessConditionDTO;
                return await Result<IAuditableEntityDTO>.SuccessAsync((dto as InstrumentItemDTO), "Updated");
            }

            return await Result<IAuditableEntityDTO>.FailAsync("Not created!");
        }
        public async Task<IResult<IAuditableEntityDTO>> OnSaveUnitsProcessConditionEquipment(IAuditableEntityDTO dto)
        {
            (dto as ProcessConditionDTO).PressureDTO = (await TablesService.ManUnit.AddUpdate(Model.EquipmentItemDTO.ProcessConditionDTO.PressureDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).TemperatureDTO = (await TablesService.ManUnit.AddUpdate(Model.EquipmentItemDTO.ProcessConditionDTO.TemperatureDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).MassFlowDTO = (await TablesService.ManUnit.AddUpdate(Model.EquipmentItemDTO.ProcessConditionDTO.MassFlowDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).VolumetricFlowDTO = (await TablesService.ManUnit.AddUpdate(Model.EquipmentItemDTO.ProcessConditionDTO.VolumetricFlowDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).DensityDTO = (await TablesService.ManUnit.AddUpdate(Model.EquipmentItemDTO.ProcessConditionDTO.DensityDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).ViscosityDTO = (await TablesService.ManUnit.AddUpdate(Model.EquipmentItemDTO.ProcessConditionDTO.ViscosityDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).EnthalpyFlowDTO = (await TablesService.ManUnit.AddUpdate(Model.EquipmentItemDTO.ProcessConditionDTO.EnthalpyFlowDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).SpecificEnthalpyDTO = (await TablesService.ManUnit.AddUpdate(Model.EquipmentItemDTO.ProcessConditionDTO.SpecificEnthalpyDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).ThermalConductivityDTO = (await TablesService.ManUnit.AddUpdate(Model.EquipmentItemDTO.ProcessConditionDTO.ThermalConductivityDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).SpecificCpDTO = (await TablesService.ManUnit.AddUpdate(Model.EquipmentItemDTO.ProcessConditionDTO.SpecificCpDTO, _cts.Token)).Data as UnitDTO;
           
            return await Result<IAuditableEntityDTO>.SuccessAsync("Created!");
        }
        public async Task<IResult<IAuditableEntityDTO>> OnSaveUnitsProcessConditionInstrument(IAuditableEntityDTO dto)
        {
            (dto as ProcessConditionDTO).PressureDTO = (await TablesService.ManUnit.AddUpdate(Model.InstrumentItemDTO.ProcessConditionDTO.PressureDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).TemperatureDTO = (await TablesService.ManUnit.AddUpdate(Model.InstrumentItemDTO.ProcessConditionDTO.TemperatureDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).MassFlowDTO = (await TablesService.ManUnit.AddUpdate(Model.InstrumentItemDTO.ProcessConditionDTO.MassFlowDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).VolumetricFlowDTO = (await TablesService.ManUnit.AddUpdate(Model.InstrumentItemDTO.ProcessConditionDTO.VolumetricFlowDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).DensityDTO = (await TablesService.ManUnit.AddUpdate(Model.InstrumentItemDTO.ProcessConditionDTO.DensityDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).ViscosityDTO = (await TablesService.ManUnit.AddUpdate(Model.InstrumentItemDTO.ProcessConditionDTO.ViscosityDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).EnthalpyFlowDTO = (await TablesService.ManUnit.AddUpdate(Model.InstrumentItemDTO.ProcessConditionDTO.EnthalpyFlowDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).SpecificEnthalpyDTO = (await TablesService.ManUnit.AddUpdate(Model.InstrumentItemDTO.ProcessConditionDTO.SpecificEnthalpyDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).ThermalConductivityDTO = (await TablesService.ManUnit.AddUpdate(Model.InstrumentItemDTO.ProcessConditionDTO.ThermalConductivityDTO, _cts.Token)).Data as UnitDTO;
            (dto as ProcessConditionDTO).SpecificCpDTO = (await TablesService.ManUnit.AddUpdate(Model.InstrumentItemDTO.ProcessConditionDTO.SpecificCpDTO, _cts.Token)).Data as UnitDTO;

            return await Result<IAuditableEntityDTO>.SuccessAsync("Created!");
        }
        
    }
}
