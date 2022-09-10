

namespace CPTool.Entities
{
    public class EHSItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
