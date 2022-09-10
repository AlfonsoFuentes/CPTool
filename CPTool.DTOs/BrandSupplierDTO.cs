using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
   
    public class BrandSupplierDTO : AuditableEntityDTO
    {
       
       
        public SupplierDTO? SupplierDTO { get; set; } 
        public BrandDTO? BrandDTO { get; set; } 

       
    }
   
}
