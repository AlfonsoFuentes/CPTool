

namespace CPTool.Entities
{
    public class FoundationItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;

    }





}
