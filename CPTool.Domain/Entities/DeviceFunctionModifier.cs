namespace CPTool.Domain.Entities
{
    public class DeviceFunctionModifier  : AuditableEntity
    {
        [ForeignKey("DeviceFunctionModifierId")]
        public ICollection<Specification>? Specifications { get; set; }
        public string? TagLetter { get; set; }
        [ForeignKey("DeviceFunctionModifierId")]
        public ICollection<MWOItem>? MWOItems { get; set; } = null!;
    }


}
