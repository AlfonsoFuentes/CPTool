using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class PipeAccesoryDTO : AuditableEntityDTO, IMapFrom<PipeAccesory>
    {
       
        
        public List<NozzleDTO>? NozzlesDTO { get; set; } = null!;

        public PipingItemDTO? PipingItemDTO { get; set; } = null!;

        public ProcessConditionDTO? ProcessConditionDTO { get; set; } = new();

        public UnitDTO? FrictionDTO { get; set; } = new();
        public UnitDTO? ReynoldDTO { get; set; } = new();

        public UnitDTO? LevelInletDTO { get; set; } = new(LengthUnits.MilliMeter);
        public UnitDTO? LevelOutletDTO { get; set; } = new(LengthUnits.MilliMeter);
        public UnitDTO? FrictionDropPressureDTO { get; set; } = new(PressureDropUnits.psi);
        public UnitDTO? OverallDropPressureDTO { get; set; } = new(PressureDropUnits.psi);
        public UnitDTO? ElevationChangeDTO { get; set; } = new(PressureDropUnits.psi);

       
        public ProcessFluidDTO? ProcessFluidDTO { get; set; } = new();



        public FlowDirection FlowDirection { get; set; }
        public PipeAccesorySectionType SectionType { get; set; }

      
    }
}
