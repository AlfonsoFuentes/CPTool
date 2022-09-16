using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
   
    public class BrandDTO : AuditableEntityDTO
    {
        public BrandType BrandType { get; set; }
        public List<BrandSupplierDTO>? BrandSupplierDTOs { get; set; } = new();
        public List<EquipmentItemDTO>? EquipmentItemDTOs { get; set; } = new();
        //public List<PurchaseOrderDTO>? PurchaseOrderDTOs { get; set; } = new();
        public string? Description { get; set; }
    }
    

}
