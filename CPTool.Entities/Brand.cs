

namespace CPTool.Entities
{
    public class Brand:AuditableEntity
    {
       
        public virtual ICollection<BrandSupplier> BrandSuppliers { get; set; } = null!;
        public virtual ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;
        public BrandType BrandType { get; set; }
        public string? Description { get; set; }

    }
}
