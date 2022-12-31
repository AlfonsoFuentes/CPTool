namespace CPTool.Domain.Entities
{
    public class PipeAccesory  : AuditableEntity
    {
        public int? pPipingItemId { get; set; }
        public PipingItem? pPipingItem { get; set; }
        public int? pProcessConditionId { get; set; }
        public ProcessCondition? pProcessCondition { get; set; }


        public int? paProcessFluidId { get; set; }
        public ProcessFluid? paProcessFluid { get; set; }
        public int? FrictionId { get; }
        public EntityUnit? Friction { get; set; }
        public int? ReynoldId { get; }
        public EntityUnit? Reynold { get; set; }
        public int? LevelInletId { get; set; }
        public EntityUnit? LevelInlet { get; set; }
        public int? LevelOutletId { get; set; }
        public EntityUnit? LevelOutlet { get; set; }
        public int? FrictionDropPressureId { get; set; }
        public EntityUnit? FrictionDropPressure { get; set; }
        public int? OverallDropPressureId { get; set; }
        public EntityUnit? OverallDropPressure { get; set; }
        public int? ElevationChangeId { get; set; }
        public EntityUnit? ElevationChange { get; set; }

        public FlowDirection FlowDirection { get; set; }
        public PipeAccesorySectionType SectionType { get; set; }
        [ForeignKey("PipeAccesoryId")]
        public ICollection<Nozzle>? Nozzles { get; set; }

        public int? paMaterialId { get; set; }
        public Material? paMaterial { get; set; }
        public int? paDiameterId { get; set; }
        public PipeDiameter? paDiameter { get; set; }
        public int? paPipeClassId { get; set; }
        public PipeClass? paPipeClass { get; set; }

    }

}
