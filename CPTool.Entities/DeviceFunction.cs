

namespace CPTool.Entities
{
    public class DeviceFunction : AuditableEntity
    {
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public string? TagLetter { get; set; }
    }


}
