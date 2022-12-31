namespace CPTool.Domain.Entities
{
    public class PaintingItem  : AuditableEntity
    {
        [ForeignKey("PaintingItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
