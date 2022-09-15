using CPTool.Entities;

namespace CPTool.DTOS
{
    public class SupplierDTO : AuditableEntityDTO
    {
        public List<BrandSupplierDTO>? BrandSupplierDTOs { get; set; } = new();
        public List<EquipmentItemDTO>? EquipmentItemDTOs { get; set; } = new();
      

        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string ContactPerson { get; set; } = "";
 

        public int? VendorCodeId => VendorCodeDTO?.Id;
        public int? TaxCodeLDId => TaxCodeLDDTO?.Id;
        public int? TaxCodeLPId => TaxCodeLPDTO?.Id;


        public VendorCodeDTO? VendorCodeDTO { get; set; } = new();        
        public TaxCodeLDDTO? TaxCodeLDDTO { get; set; } = new();        
        public TaxCodeLPDTO? TaxCodeLPDTO { get; set; } = new();
    }
   
}
