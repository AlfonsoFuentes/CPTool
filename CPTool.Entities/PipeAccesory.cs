

namespace CPTool.Entities
{
    public class PipeAccesory : AuditableEntity
    {
        public int? PipingItemId { get; set; }
        public PipingItem? PipingItem { get; set; }
        public int? ProcessConditionId { get; set; }
        public ProcessCondition? ProcessCondition { get; set; }

        public int? ProcessFluidId { get; set; }
        public ProcessFluid? ProcessFluid { get; set; }
        public int? FrictionId { get; }
        public Unit? Friction { get; set; }
        public int? ReynoldId { get; }
        public Unit? Reynold { get; set; }
        public int? LevelInletId { get; set; }
        public Unit? LevelInlet { get; set; }
        public int? LevelOutletId { get; set; }
        public Unit? LevelOutlet { get; set; }
        public int? FrictionDropPressureId { get; set; }
        public Unit? FrictionDropPressure { get; set; }
        public int? OverallDropPressureId { get; set; }
        public Unit? OverallDropPressure { get; set; }
        public int? ElevationChangeId { get; set; }
        public Unit? ElevationChange { get; set; }
      
        public FlowDirection FlowDirection { get; set; }
        public PipeAccesorySectionType SectionType { get; set; }

        public ICollection<Nozzle>? Nozzles { get; set; }
    }

}
