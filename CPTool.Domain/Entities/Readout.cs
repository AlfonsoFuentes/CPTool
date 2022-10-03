namespace CPTool.Domain.Entities
{
    public class Readout  : BaseDomainModel
    {
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public string? TagLetter { get; set; }
    }


}
