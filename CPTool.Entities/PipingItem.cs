

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

        public PipeClass? PipeClass { get; set; }
        public int? MaterialId { get; set; }
        public int? ProcessFluidId { get; set; }
        public int? DiameterId { get; set; }
        public int? NozzleStartId { get; set; }
        public int? NozzleFinishId { get; set; }
        public int? StartMWOItemId { get; set; }
        public int? FinishMWOItemId { get; set; }
        public int? PipeClassId { get; set; }
        public bool Insulation { get; set; }


    }
    public class ProcessFluid : AuditableEntity
    {
        public ICollection<EquipmentItem>? EquipmentItems { get; set; } = null!;
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        public ICollection<ProcessCondition>? ProcessCondition { get; set; } = null!;
    }
    public class PipeDiameter : AuditableEntity
    {
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;

        public Unit? OD { get; set; }
        public Unit? ID { get; set; }
        public Unit? Thickness { get; set; }


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
        public int? MaterialID { get; set; }
        public Material? Material { get; set; }

        public StreamType StreamType { get; set; }

        public PipeAccesory? PipeAccesory { get; set; }
        public int? PipeAccesoryId { get; set; }


    }
    public enum StreamType
    {
        None,
        Inlet,
        Outlet
    }
    public class PipeAccesory : AuditableEntity
    {
        public int? PipingItemId { get; set; }
        public PipingItem? PipingItem { get; set; }
        public int? ProcessConditionId { get; set; }
        public ProcessCondition? ProcessCondition { get; set; }

        public Unit? Friction { get; }
        public Unit? Reynold { get; }

        public Unit? LevelInlet { get; set; }
        public Unit? LevelOutlet { get; set; }
        public Unit? FrictionDropPressure { get; set; }
        public Unit? OverallDropPressure { get; set; }
        public Unit? ElevationChange { get; set; }
        public int? FrictionId { get; }
        public int? ReynoldId { get; }
        public int? LevelInletId { get; set; }
        public int? LevelOutletId { get; set; }
        public int? FrictionDropPressureId { get; set; }
        public int? OverallDropPressureId { get; set; }
        public int? ElevationChangeId { get; set; }

        public FlowDirection FlowDirection { get; set; }
        public PipeAccesorySectionType SectionType { get; set; }

        public ICollection<Nozzle>? Nozzles { get; set; }
    }
    public enum FlowDirection
    {
        None,
        Up,
        Straigth,
        Down
    }
    public enum PipeAccesorySectionType
    {
        None,

        OutletVessel,
        InletVessel,
        Tube,
        Elbow90,
        Elbow45,
        BallValve,
        Butterfly,
        ProportionalValve,
        CheckValve,
        POU,
        Reducer,
        Expansion,
        FlowMeter

    }
    public class PipeClass : AuditableEntity
    {

        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
    }
    public class ConnectionType : AuditableEntity
    {
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
    }
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
