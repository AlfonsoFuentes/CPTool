

namespace CPTool.Entities
{
    public class MeasuredVariableModifier : AuditableEntity
    {
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public string? TagLetter { get; set; }
    }


}
