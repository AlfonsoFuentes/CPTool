namespace CPTool.Domain.Entities
{
    public class InstrumentItem  : BaseDomainModel
    {
        [ForeignKey("InstrumentItemId")]
        public ICollection<MWOItem>? MWOItems { get; set; } = null!;
        public int? iProcessConditionId { get; set; }
        public ProcessCondition? iProcessCondition { get; set; }
        public int? iProcessFluidId { get; set; }
        public ProcessFluid? iProcessFluid { get; set; }

        [ForeignKey("InstrumentItemId")]
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
    
        public int? iGasketId { get; set; }
        public Gasket? iGasket { get; set; } = null!;
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

        public int? iBrandId { get; set; }
        public Brand? iBrand { get; set; }
        public int? iSupplierId { get; set; }
        public Supplier? iSupplier { get; set; }
        public string TagId { get; set; } = string.Empty;
        public string? TagLetter { get; set; }
        public string? TagNumber { get; set; }
        public string? Model { get; set; }
        public string? Reference { get; set; }
        public string? SerialNumber { get; set; }
    }


}
