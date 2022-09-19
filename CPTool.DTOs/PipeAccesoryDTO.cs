using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class PipeAccesoryDTO : AuditableEntityDTO
    {
        public ICollection<NozzleDTO>? NozzlesDTO { get; set; }
      
        public PipingItemDTO? PipingItemDTO { get; set; }
     
        public ProcessConditionDTO? ProcessConditionDTO { get; set; }

        public UnitDTO? FrictionDTO { get; }
        public UnitDTO? ReynoldDTO { get; }

        public UnitDTO? LevelInletDTO { get; set; }
        public UnitDTO? LevelOutletDTO { get; set; }
        public UnitDTO? FrictionDropPressureDTO { get; set; }
        public UnitDTO? OverallDropPressureDTO { get; set; }
        public UnitDTO? ElevationChangeDTO { get; set; }

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
