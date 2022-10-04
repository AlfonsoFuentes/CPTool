namespace CPTool.Domain.Entities
{
    public class Brand : BaseDomainModel
    {

       
        public ICollection<BrandSupplier> BrandSuppliers { get; set; } = null!;
        public ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;

        public ICollection<InstrumentItem> InstrumentItems { get; set; } = null!;
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public BrandType BrandType { get; set; }


    }
}
