namespace CPTool.Domain.Entities
{
    public class MeasuredVariable  : BaseDomainModel
    {
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public string? TagLetter { get; set; }
    }


}
