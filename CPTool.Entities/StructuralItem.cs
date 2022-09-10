

namespace CPTool.Entities
{
    public class StructuralItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;

    }





}
