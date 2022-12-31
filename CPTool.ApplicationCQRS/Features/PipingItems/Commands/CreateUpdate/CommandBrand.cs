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


        public List<CommandPipeAccesory> PipeAccesorys { get; set; } = new();
        public List<CommandNozzle>? Nozzles { get; set; } = new();
        public int? pProcessConditionId => pProcessCondition?.Id == 0 ? null : pProcessCondition?.Id;
        public CommandProcessCondition? pProcessCondition { get; set; } = new();
        public int? pMaterialId => pMaterial?.Id == 0 ? null : pMaterial?.Id;
        CommandMaterial? _pMaterial = new();
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
        public CommandPipeDiameter? pDiameter
        {
            get { return _pDiameter; }
            set { _pDiameter = value;
                _TagId= SetTagId();
            }
        }
        public int? NozzleStartId => NozzleStart?.Id == 0 ? null : NozzleStart?.Id;
        public CommandNozzle? NozzleStart { get; set; }
        public int? NozzleFinishId => NozzleFinish?.Id == 0 ? null : NozzleFinish?.Id;
        public CommandNozzle? NozzleFinish { get; set; }
        public int? StartMWOItemId => StartMWOItem?.Id == 0 ? null : StartMWOItem?.Id;
        public CommandMWOItem? StartMWOItem { get; set; }
        public int? FinishMWOItemId => FinishMWOItem?.Id == 0 ? null : FinishMWOItem?.Id;
        public CommandMWOItem? FinishMWOItem { get; set; }
        public int? pPipeClassId => pPipeClass?.Id == 0 ? null : pPipeClass?.Id;
        public CommandPipeClass? pPipeClass { get; set; } = new();
        string _TagId = string.Empty;
        public string TagId { get => _TagId; set => _TagId = value; }
        public bool Insulation { get; set; }
      
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
            if (pDiameter == null) return "";
            if (pMaterial == null) return $"{pDiameter?.Name}";
            if (pProcessFluid == null) return $"{pDiameter?.Name}-{pMaterial?.Abbreviation}";
            if (TagNumber == "") return $"{pDiameter?.Name}-{pMaterial?.Abbreviation}-{pProcessFluid?.TagLetter}";

            var tag = $"{pDiameter?.Name}-{pMaterial?.Abbreviation}-{pProcessFluid?.TagLetter}-{TagNumber}-{(Insulation ? 1 : 0)}";

            return tag;
        }

    }

}
