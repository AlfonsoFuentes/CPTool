

namespace CPTool.Entities
{
    public class Unit : AuditableEntity
    {
        public string? UnitName { get; set; }
        public double Value { get; set; }

        [ForeignKey("ODId")]
        public ICollection<PipeDiameter>? ODs { get; set; } = null!;
        [ForeignKey("IDId")]
        public ICollection<PipeDiameter>? IDs { get; set; } = null!;
        [ForeignKey("ThicknessId")]
        public ICollection<PipeDiameter>? Thicknesss { get; set; } = null!;


        [ForeignKey("SpecificCpId")]
        public ICollection<ProcessCondition>? SpecificCps { get; set; } = null!;
        [ForeignKey("ThermalConductivityId")]
        public ICollection<ProcessCondition>? ThermalConductivitys { get; set; } = null!;

        [ForeignKey("SpecificEnthalpyId")]
        public ICollection<ProcessCondition>? SpecificEnthalpys { get; set; } = null!;
        [ForeignKey("EnthalpyFlowId")]
        public ICollection<ProcessCondition>? EnthalpyFlows { get; set; } = null!;
        [ForeignKey("ViscosityId")]
        public ICollection<ProcessCondition>? Viscositys { get; set; } = null!;
        [ForeignKey("DensityId")]
        public ICollection<ProcessCondition>? Densitys { get; set; } = null!;
        [ForeignKey("VolumetricFlowId")]
        public ICollection<ProcessCondition>? VolumetricFlows { get; set; } = null!;
        [ForeignKey("MassFlowId")]
        public ICollection<ProcessCondition>? MassFlows { get; set; } = null!;
        [ForeignKey("TemperatureId")]
        public ICollection<ProcessCondition>? Temperatures { get; set; } = null!;
        [ForeignKey("PressureId")]
        public ICollection<ProcessCondition>? Pressures { get; set; } = null!;
        [ForeignKey("FrictionId")]
        public ICollection<PipeAccesory>? FrictionPipeAccesorys { get; set; } = null!;
        [ForeignKey("ReynoldId")]
        public ICollection<PipeAccesory>? ReynoldPipeAccesorys { get; set; } = null!;
        [ForeignKey("LevelInletId")]
        public ICollection<PipeAccesory>? LevelInletPipeAccesorys { get; set; } = null!;
        [ForeignKey("LevelOutletId")]
        public ICollection<PipeAccesory>? LevelOutletPipeAccesorys { get; set; } = null!;
        [ForeignKey("FrictionDropPressureId")]
        public ICollection<PipeAccesory>? FrictionDropPressurePipeAccesorys { get; set; } = null!;
        [ForeignKey("OverallDropPressureId")]
        public ICollection<PipeAccesory>? OverallDropPressurePipeAccesorys { get; set; } = null!;
        [ForeignKey("ElevationChangeId")]
        public ICollection<PipeAccesory>? ElevationChangePipeAccesorys { get; set; } = null!;
    }

}
