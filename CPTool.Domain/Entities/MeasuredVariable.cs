namespace CPTool.Domain.Entities
{
    public class MeasuredVariable  : BaseDomainModel
    {
        [ForeignKey("MeasuredVariableId")]
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public string? TagLetter { get; set; }
    }


}
