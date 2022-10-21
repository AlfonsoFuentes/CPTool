namespace CPTool.Domain.Entities
{
    public class DeviceFunctionModifier  : BaseDomainModel
    {
        [ForeignKey("DeviceFunctionModifierId")]
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public string? TagLetter { get; set; }
    }


}
