

namespace CPTool.Entities
{
    public class PipingItem : AuditableEntity
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
        public ICollection<PipeAccesory> PipeAccesorys { get; set; } = null!;
        public Material? Material { get; set; }
        public ProcessFluid? ProcessFluid { get; set; }
        public PipeDiameter? Diameter { get; set; }
        public Nozzle? NozzleStart { get; set; }
        public Nozzle? NozzleFinish { get; set; }
        public MWOItem? StartMWOItem { get; set; }
        public MWOItem? FinishMWOItem { get; set; }
        public int? MaterialId { get; set; }
        public int? ProcessFluidId { get; set; }
        public int? DiameterId { get; set; }
        public int? NozzleStartId { get; set; }
        public int? NozzleFinishId { get; set; }
        public int? StartMWOItemId { get; set; }
        public int? FinishMWOItemId { get; set; }

        public bool Insulation { get; set; }

       
    }
    public class ProcessFluid : AuditableEntity
    {
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
    }
    public class PipeDiameter : AuditableEntity
    {
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;

        public Unit? OD { get; set; }
        public Unit? ID { get; set; }
        public Unit? Thickness { get; set; }
        public PipeClass? PipeClass { get; set; }

        public int? ODId { get; set; }
        public int? IDId { get; set; }
        public int? ThicknessId { get; set; }
    }

  

    public class Nozzle : AuditableEntity
    {
        [ForeignKey("NozzleStartId")]
        public ICollection<PipingItem>? StartPipingItems { get; set; } = null!;
        [ForeignKey("NozzleFinishId")]
        public ICollection<PipingItem>? FinishPipingItems { get; set; } = null!;

        public int? PipeClassId { get; set; }
        public PipeClass? PipeClass { get; set; }

        public int? PipeDiameterId { get; set; }
        public PipeDiameter? PipeDiameter { get; set; }
        public int? ConnectionTypeId { get; set; }
        public ConnectionType? ConnectionType { get; set; }
        public int? GasketId { get; set; }
        public Gasket? Gasket { get; set; }

        public int? ProcessConditionId { get; set; }
        public ProcessCondition? ProcessCondition { get; set; }

       

    }
    public class PipeAccesory : AuditableEntity
    {
        public int? PipingItemId { get; set; }
        public PipingItem? PipingItem { get; set; }
        public int? ProcessConditionId { get; set; }
        public ProcessCondition? ProcessCondition { get; set; }
    }
    public class PipeClass:AuditableEntity
    {
        public ICollection<PipeDiameter>? PipeDiameters { get; set; } = null!;
    }
    public class ConnectionType : AuditableEntity
    {
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
    }
    public class ProcessCondition : AuditableEntity
    {
        public ICollection<PipeAccesory>? PipeAccesorys { get; set; } = null!;
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
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
    }

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
    }

}
