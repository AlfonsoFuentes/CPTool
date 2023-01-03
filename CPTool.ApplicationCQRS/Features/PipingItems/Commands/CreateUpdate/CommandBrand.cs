using CPTool.ApplicationCQRS.Features.Materials.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate
{
    public class CommandPipingItem : CommandBase, IRequest<PipingItemCommandResponse>
    {

        public CommandMWOItem MWOItem { get; set; } = new();
        public List<CommandPipeAccesory> PipeAccesorys { get; set; } = new();
        public List<CommandNozzle>? Nozzles { get; set; } = new();
        public int? pProcessConditionId => pProcessCondition?.Id == 0 ? null : pProcessCondition?.Id;
        public CommandProcessCondition? pProcessCondition { get; set; } = new();
        public int? pMaterialId => pMaterial?.Id == 0 ? null : pMaterial?.Id;
        CommandMaterial? _pMaterial = new();

        public string MaterialName => _pMaterial == null ? "" : _pMaterial.Name;
        public CommandMaterial? pMaterial
        {
            get { return _pMaterial; }
            set
            {
                _pMaterial = value;
                _TagId = SetTagId();
            }
        }
        public int? pProcessFluidId => pProcessFluid?.Id == 0 ? null : pProcessFluid?.Id;
        public string ProcessFluidName => _pProcessFluid == null ? "" : _pProcessFluid.Name;
        CommandProcessFluid? _pProcessFluid = new();
        public CommandProcessFluid? pProcessFluid
        {
            get { return _pProcessFluid; }
            set
            {
                _pProcessFluid = value;
                _TagId = SetTagId();
            }
        }
        public int? pDiameterId => pDiameter?.Id == 0 ? null : pDiameter?.Id;
        CommandPipeDiameter? _pDiameter = new();
        public string DiameterName => _pDiameter == null ? "" : _pDiameter.Name;
        public CommandPipeDiameter? pDiameter
        {
            get { return _pDiameter; }
            set { _pDiameter = value;
                _TagId= SetTagId();
            }
        }
        public int? NozzleStartId => NozzleStart?.Id == 0 ? null : NozzleStart?.Id;

        public string NozzleStartName => NozzleStart == null ? "" : NozzleStart.NameDescription;
        public CommandNozzle? NozzleStart { get; set; }
        public int? NozzleFinishId => NozzleFinish?.Id == 0 ? null : NozzleFinish?.Id;

        public string NozzleFinishName => NozzleFinish == null ? "" : NozzleFinish.NameDescription;
        public CommandNozzle? NozzleFinish { get; set; }
        public int? StartMWOItemId => StartMWOItem?.Id == 0 ? null : StartMWOItem?.Id;
        public string StartMWOItemName => StartMWOItem == null ? "" : StartMWOItem.TagId;
        public CommandMWOItem? StartMWOItem { get; set; }
        public int? FinishMWOItemId => FinishMWOItem?.Id == 0 ? null : FinishMWOItem?.Id;

        public string FinishMWOItemName => FinishMWOItem == null ? "" : FinishMWOItem.TagId;
        public CommandMWOItem? FinishMWOItem { get; set; }
        public int? pPipeClassId => pPipeClass?.Id == 0 ? null : pPipeClass?.Id;
        public string ClassName => pPipeClass == null ? "" : pPipeClass.Name;
        public CommandPipeClass? pPipeClass { get; set; } = new();
        string _TagId = string.Empty;
        public string TagId { get => _TagId; set => _TagId = value; }

        bool _Insulation;
        public bool Insulation
        {
            get
            {
                return _Insulation;
            }
            set
            {
                _Insulation = value;
                _TagId = SetTagId();
            }
        }
        string _TagNumber = string.Empty;
        public string TagNumber
        {
            get { return _TagNumber; }
            set
            {
                _TagNumber = value;
                _TagId = SetTagId();
            }
        }
        string SetTagId()
        {
            if (_pDiameter == null) return "";
            if (_pMaterial == null) return $"{_pDiameter?.Name}";
            if (pProcessFluid == null) return $"{_pDiameter?.Name}-{_pMaterial?.Abbreviation}";
            if (_TagNumber == "") return $"{_pDiameter?.Name}-{_pMaterial?.Abbreviation}-{_pProcessFluid?.TagLetter}";

            var tag = $"{_pDiameter?.Name}-{_pMaterial?.Abbreviation}-{_pProcessFluid?.TagLetter}-{_TagNumber}-{(_Insulation ? 1 : 0)}";

            return tag;
        }

    }

}
