

namespace CPTool.Entities
{
    public class BrandSupplier : AuditableEntity
    {
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; } = null!;

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;

    }
}
