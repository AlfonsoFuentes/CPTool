

namespace CPTool.Entities
{
    public class PaintingItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
