namespace CPTool.Entities
{
    public class Chapter : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
        public string? Letter { get; set; }
    }
}
