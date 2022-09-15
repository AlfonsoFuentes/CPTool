

namespace CPTool.Entities
{
    public class TaxCodeLD : AuditableEntity
    {
        public  ICollection<Supplier> Suppliers { get; set; } = null!;
    }
}
