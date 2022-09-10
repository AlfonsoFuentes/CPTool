

namespace CPTool.Entities
{
    public class ContingencyItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
