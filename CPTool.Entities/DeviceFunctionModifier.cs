

namespace CPTool.Entities
{
    public class DeviceFunctionModifier : AuditableEntity
    {
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public string? TagLetter { get; set; }
    }


}
