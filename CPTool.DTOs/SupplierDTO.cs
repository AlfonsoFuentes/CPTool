using CPTool.Entities;

namespace CPTool.DTOS
{
    public class SupplierDTO : AuditableEntityDTO, IMapFrom<Supplier>
    {
        public List<BrandSupplierDTO>? BrandSupplierDTOs { get; set; } = new();
        public List<EquipmentItemDTO>? EquipmentItemDTOs { get; set; } = new();
        public List<InstrumentItemDTO>? InstrumentItemDTOs { get; set; } = new();
        public List<PurchaseOrderDTO>? PurchaseOrderDTOs { get; set; } = new();
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string ContactPerson { get; set; } = "";
 

      


        public VendorCodeDTO? VendorCodeDTO { get; set; } = new();        
        public TaxCodeLDDTO? TaxCodeLDDTO { get; set; } = new();        
        public TaxCodeLPDTO? TaxCodeLPDTO { get; set; } = new();
    }
   
}
