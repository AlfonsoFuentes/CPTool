namespace CPTool.Domain.Entities
{
    public class DeviceFunction  : BaseDomainModel
    {
        [ForeignKey("DeviceFunctionId")]
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public string? TagLetter { get; set; }
    }


}
