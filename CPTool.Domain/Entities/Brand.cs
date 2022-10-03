namespace CPTool.Domain.Entities
{
    public class Brand : BaseDomainModel
    {

        public Brand()
        {
            Suppliers = new HashSet<Supplier>();
        }
        public ICollection<Supplier> Suppliers { get; set; } = null!;
        public ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;

        public ICollection<InstrumentItem> InstrumentItems { get; set; } = null!;
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public BrandType BrandType { get; set; }


    }
}
