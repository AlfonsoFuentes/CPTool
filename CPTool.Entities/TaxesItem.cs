

namespace CPTool.Entities
{
    public class TaxesItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
    }

}
