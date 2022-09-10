

namespace CPTool.Entities
{
    public class PipingItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
