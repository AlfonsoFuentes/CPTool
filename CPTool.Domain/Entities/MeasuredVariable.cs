namespace CPTool.Domain.Entities
{
    public class MeasuredVariable  : AuditableEntity
    {
        [ForeignKey("MeasuredVariableId")]
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public string? TagLetter { get; set; }
    }


}
