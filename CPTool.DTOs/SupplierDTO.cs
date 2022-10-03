using CPTool.Entities;

namespace CPTool.DTOS
{
    public class SupplierDTO : AuditableEntityDTO, IMapFrom<Supplier>
    {
        public List<BrandSupplierDTO>? BrandSuppliersDTO { get; set; } = new();
        public List<EquipmentItemDTO>? EquipmentItemsDTO { get; set; } = new();
        public List<InstrumentItemDTO>? InstrumentItemsDTO { get; set; } = new();
        public List<PurchaseOrderDTO>? PurchaseOrdersDTO { get; set; } = new();
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string ContactPerson { get; set; } = "";
 

      


        public VendorCodeDTO? VendorCodeDTO { get; set; } = new();        
        public TaxCodeLDDTO? TaxCodeLDDTO { get; set; } = new();        
        public TaxCodeLPDTO? TaxCodeLPDTO { get; set; } = new();
    }
   
}
