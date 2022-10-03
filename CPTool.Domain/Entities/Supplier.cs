namespace CPTool.Domain.Entities
{
    public class Supplier  : BaseDomainModel
    {
        public Supplier()
        {
            Brands = new HashSet<Brand>();
        }

        public ICollection<EquipmentItem> EquipmentItems { get; set; } = null!;
        public ICollection<Brand> Brands { get; set; } = null!;
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; } = null!;

        public ICollection<InstrumentItem> InstrumentItems { get; set; } = null!;
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";


        public string Email { get; set; } = "";
        public string ContactPerson { get; set; } = "";


        public int? TaxCodeLPId { get; set; }
        public TaxCodeLP? TaxCodeLP { get; set; }
        public int? TaxCodeLDId { get; set; }
        public VendorCode? VendorCode { get; set; }
        public int? VendorCodeId { get; set; }
        public TaxCodeLD? TaxCodeLD { get; set; }
    }

}
