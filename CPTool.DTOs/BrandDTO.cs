using CPTool.Entities;
using CPTool.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
   
    public class BrandDTO : AuditableEntityDTO, IMapFrom<Brand>
    {
        public BrandType BrandType { get; set; }
        public List<BrandSupplierDTO>? BrandSuppliersDTO { get; set; } = new();
        public List<EquipmentItemDTO>? EquipmentItemsDTO { get; set; } = new();

        public List<InstrumentItemDTO>? InstrumentItemsDTO { get; set; } = new();
        public List<PurchaseOrderDTO>? PurchaseOrdersDTO { get; set; } = new();
    }
    

}
