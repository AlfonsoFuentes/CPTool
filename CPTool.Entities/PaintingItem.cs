

namespace CPTool.Entities
{
    public class PaintingItem : AuditableEntity
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
