namespace CPTool.Domain.Entities
{
    public class Chapter  : AuditableEntity
    {
        [ForeignKey("ChapterId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
        public string? Letter { get; set; }
    }
}
