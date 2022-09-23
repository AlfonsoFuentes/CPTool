

namespace CPTool.Entities
{
    public class TaxesItem : AuditableEntity
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }

}
