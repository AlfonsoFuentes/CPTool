namespace CPTool.Domain.Entities
{
    public class InstrumentItem  : BaseDomainModel
    {
        public int? ProcessConditionId { get; set; }
        public ProcessCondition? ProcessCondition { get; set; }
        public int? ProcessFluidInstrumentId { get; set; }
        public ProcessFluid? ProcessFluidInstrument { get; set; }
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
        public ICollection<MWOItem>? MWOItems { get; set; } = null!;
        public int? GasketId { get; set; }
        public Gasket? Gasket { get; set; } = null!;
        public int? iInnerMaterialId { get; set; }
        public Material? iInnerMaterial { get; set; } = null!;
        public int? iOuterMaterialId { get; set; }
        public Material? iOuterMaterial { get; set; } = null!;
        public int? MeasuredVariableId { get; set; }
        public MeasuredVariable? MeasuredVariable { get; set; }
        public int? MeasuredVariableModifierId { get; set; }
        public MeasuredVariableModifier? MeasuredVariableModifier { get; set; }
        public int? DeviceFunctionId { get; set; }
        public DeviceFunction? DeviceFunction { get; set; }
        public int? DeviceFunctionModifierId { get; set; }
        public DeviceFunctionModifier? DeviceFunctionModifier { get; set; }
        public int? ReadoutId { get; set; }
        public Readout? Readout { get; set; }

        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public string TagId { get; set; } = string.Empty;
        public string? TagLetter { get; set; }
        public string? TagNumber { get; set; }
        public string? Model { get; set; }
        public string? Reference { get; set; }
        public string? SerialNumber { get; set; }
    }


}
