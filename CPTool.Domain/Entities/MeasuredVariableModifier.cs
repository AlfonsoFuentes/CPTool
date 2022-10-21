namespace CPTool.Domain.Entities
{
    public class MeasuredVariableModifier  : BaseDomainModel
    {
        [ForeignKey("MeasuredVariableModifierId")]
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public string? TagLetter { get; set; }
    }


}
