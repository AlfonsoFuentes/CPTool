

namespace CPTool.Entities
{
    public class TaxCodeLP : AuditableEntity
    {
        public  ICollection<Supplier>? Suppliers { get; set; } 
    }
}
