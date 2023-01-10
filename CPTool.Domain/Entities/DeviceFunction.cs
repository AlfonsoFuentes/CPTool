namespace CPTool.Domain.Entities
{
    public class DeviceFunction  : AuditableEntity
    {
        [ForeignKey("DeviceFunctionId")]
        public ICollection<Specification>? Specifications { get; set; }
        public string? TagLetter { get; set; }
        [ForeignKey("DeviceFunctionId")]
        public ICollection<MWOItem>? MWOItems { get; set; } = null!;
    }


}
