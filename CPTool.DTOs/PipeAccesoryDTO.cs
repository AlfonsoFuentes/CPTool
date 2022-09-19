using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class PipeAccesoryDTO : AuditableEntityDTO
    {
       
        public List<NozzleDTO>? NozzlesDTO { get; set; } = new();

        public PipingItemDTO? PipingItemDTO { get; set; } = new();

        public ProcessConditionDTO? ProcessConditionDTO { get; set; } = new();

        public UnitDTO? FrictionDTO { get; set; } = new()
        {
            Amount = new UnitLess()
        };
        public UnitDTO? ReynoldDTO { get; set; } = new()
        {
            Amount = new UnitLess()
        };

        public UnitDTO? LevelInletDTO { get; set; } = new()
        {
            Amount = new Length(LengthUnits.MilliMeter)
        };
        public UnitDTO? LevelOutletDTO { get; set; } = new()
        {
            Amount = new Length(LengthUnits.MilliMeter)
        };
        public UnitDTO? FrictionDropPressureDTO { get; set; } = new()
        {
            Amount = new DropPressure(DropPressureUnits.psi)
        };
        public UnitDTO? OverallDropPressureDTO { get; set; } = new()
        {
            Amount = new DropPressure(DropPressureUnits.psi)
        };
        public UnitDTO? ElevationChangeDTO { get; set; } = new()
        {
            Amount = new DropPressure(DropPressureUnits.psi)
        };

        public int? ProcessConditionId => ProcessConditionDTO?.Id;

        public int? PipingItemId => PipingItemDTO?.Id;
        public int? FrictionId => FrictionDTO?.Id;
        public int? ReynoldId => ReynoldDTO?.Id;
        public int? LevelInletId => LevelInletDTO?.Id;
        public int? LevelOutletId => LevelOutletDTO?.Id;
        public int? FrictionDropPressureId => FrictionDropPressureDTO?.Id;
        public int? OverallDropPressureId => OverallDropPressureDTO?.Id;
        public int? ElevationChangeId => ElevationChangeDTO?.Id;

        public FlowDirection FlowDirection { get; set; }
        public PipeAccesorySectionType SectionType { get; set; }

      
    }
}
