

namespace CPTool.Entities
{
    public class Brand:AuditableEntity
    {
       
        public  ICollection<BrandSupplier> BrandSuppliers { get; set; } = null!;
        public  ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;

        public ICollection<InstrumentItem> InstrumentItems { get; set; } = null!;
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public BrandType BrandType { get; set; }
      

    }
}
