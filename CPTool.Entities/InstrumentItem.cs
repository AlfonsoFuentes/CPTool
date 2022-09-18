

namespace CPTool.Entities
{
    public class InstrumentItem : AuditableEntity
    {
        public  ICollection<MWOItem> MWOItems { get; set; } = null!;
        public MaterialsGroup? MaterialsGroup { get; set; }
        public MeasuredVariable? MeasuredVariable { get; set; }
        public MeasuredVariableModifier? MeasuredVariableModifier { get; set; }
        public DeviceFunction? DeviceFunction { get; set; }
        public DeviceFunctionModifier? DeviceFunctionModifier { get; set; }
        public Readout? Readout { get; set; }
        public Brand? Brand { get; set; }
        public Supplier? Supplier { get; set; }


        public int? MaterialsGroupId { get; set; }
        public int? InnerMaterialId { get; set; }
        public int? OuterMaterialId { get; set; }
        public int? MeasuredVariableId { get; set; }
        public int? MeasuredVariableModifierId { get; set; }
        public int? DeviceFunctionId { get; set; }
        public int? DeviceFunctionModifierId { get; set; }
        public int? ReadoutId { get; set; }
        public int? BrandId { get; set; }
        public int? SupplierId { get; set; }
       
        public string? TagId { get; set; }
        public string? TagLetter { get; set; }
        public string? TagNumber { get; set; }
        public string? Model { get; set; }
        public string? Reference { get; set; }
        public string? SerialNumber { get; set; }
    }


}
