namespace CPTool.Domain.Entities
{
    public class ProcessCondition  : BaseDomainModel
    {
        [ForeignKey("pProcessConditionId")]
        public ICollection<PipeAccesory>? PipeAccesorys { get; set; } = null!;
        [ForeignKey("eProcessConditionId")]
        public ICollection<EquipmentItem>? EquipmentItems { get; set; } = null!;
        [ForeignKey("iProcessConditionId")]
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;

        [ForeignKey("pProcessConditionId")]
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        public int? PressureId { get; set; }
        public EntityUnit? Pressure { get; set; }
        public int? TemperatureId { get; set; }
        public EntityUnit? Temperature { get; set; }
        public int? MassFlowId { get; set; }
        public EntityUnit? MassFlow { get; set; }
        public int? VolumetricFlowId { get; set; }
        public EntityUnit? VolumetricFlow { get; set; }
        public int? DensityId { get; set; }
        public EntityUnit? Density { get; set; }
        public int? ViscosityId { get; set; }
        public EntityUnit? Viscosity { get; set; }
        public int? EnthalpyFlowId { get; set; }
        public EntityUnit? EnthalpyFlow { get; set; }
        public int? SpecificEnthalpyId { get; set; }
        public EntityUnit? SpecificEnthalpy { get; set; }
        public int? ThermalConductivityId { get; set; }
        public EntityUnit? ThermalConductivity { get; set; }
        public int? SpecificCpId { get; set; }
        public EntityUnit? SpecificCp { get; set; }

    }

}
