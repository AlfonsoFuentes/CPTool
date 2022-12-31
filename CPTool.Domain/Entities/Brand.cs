using CPTool.Domain.Enums;

namespace CPTool.Domain.Entities
{
    public class Brand : AuditableEntity
    {

       
        public ICollection<BrandSupplier> BrandSuppliers { get; set; } = null!;
        [ForeignKey("eBrandId")]
        public ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;
        [ForeignKey("iBrandId")]
        public ICollection<InstrumentItem> InstrumentItems { get; set; } = null!;
        [ForeignKey("pBrandId")]
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public BrandType BrandType { get; set; }


    }
}
