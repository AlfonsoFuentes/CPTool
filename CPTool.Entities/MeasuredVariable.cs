

namespace CPTool.Entities
{
    public class MeasuredVariable : AuditableEntity
    {
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public string? TagLetter { get; set; }
    }


}
