

namespace CPTool.Entities
{
    public class Readout : AuditableEntity
    {
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public string? TagLetter { get; set; }
    }


}
