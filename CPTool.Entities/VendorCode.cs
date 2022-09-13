

namespace CPTool.Entities
{
    public class VendorCode : AuditableEntity
    {
        public  ICollection<Supplier>? Suppliers { get; set; } 
    }
}
