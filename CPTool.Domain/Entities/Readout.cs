namespace CPTool.Domain.Entities
{
    public class Readout  : AuditableEntity
    {
        [ForeignKey("ReadoutId")]
        public ICollection<Specification>? Specifications { get; set; }
        public string? TagLetter { get; set; }
        [ForeignKey("ReadoutId")]
        public ICollection<MWOItem>? MWOItems { get; set; } = null!;
    }


}
