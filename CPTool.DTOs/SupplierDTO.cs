using CPTool.Entities;

namespace CPTool.DTOS
{
    public class SupplierDTO : AuditableEntityDTO
    {
        public List<BrandSupplierDTO> BrandSupplierDTOs { get; set; } = new();
        public List<EquipmentItemDTO> EquipmentItemDTOs { get; set; } = new();
        public string VendorCode { get; set; } = "";

        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";


        public string Email { get; set; } = "";
        public string ContactPerson { get; set; } = "";
        public string TaxCodeLD { get; set; } = "";
        public string TaxCodeLP { get; set; } = "";
    }
   
}
