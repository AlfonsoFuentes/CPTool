namespace CPTool.Entities
{
    public class Chapter : AuditableEntity
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
        public string? Letter { get; set; }
    }
}
