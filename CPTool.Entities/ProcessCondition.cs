

namespace CPTool.Entities
{
    public class ProcessCondition : AuditableEntity
    {

        public ICollection<PipeAccesory>? PipeAccesorys { get; set; } = null!;
        public ICollection<EquipmentItem>? EquipmentItems { get; set; } = null!;
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public Unit? Pressure { get; set; }
        public Unit? Temperature { get; set; }
        public Unit? MassFlow { get; set; }
        public Unit? VolumetricFlow { get; set; }
        public Unit? Density { get; set; }
        public Unit? Viscosity { get; set; }
        public Unit? EnthalpyFlow { get; set; }
        public Unit? SpecificEnthalpy { get; set; }
        public Unit? ThermalConductivity { get; set; }
        public Unit? SpecificCp { get; set; }
        public ProcessFluid? ProcessFluid { get; set; }
        public int? PressureId { get; set; }
        public int? TemperatureId { get; set; }
        public int? MassFlowId { get; set; }
        public int? VolumetricFlowId { get; set; }
        public int? DensityId { get; set; }
        public int? ViscosityId { get; set; }
        public int? EnthalpyFlowId { get; set; }
        public int? SpecificEnthalpyId { get; set; }
        public int? ThermalConductivityId { get; set; }
        public int? SpecificCpId { get; set; }
        public int? ProcessFluidId { get; set; }
    }

}
