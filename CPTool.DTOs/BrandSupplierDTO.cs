using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
   
    public class BrandSupplierDTO : AuditableEntityDTO
    {

        public int BrandId => BrandDTO.Id;
        public SupplierDTO SupplierDTO { get; set; } = new();
        public int SupplierId => SupplierDTO.Id;
        public BrandDTO BrandDTO { get; set; } = new();


    }
    public class CreateBrandSupplierDTO : BrandSupplierDTO
    {

    }
}
