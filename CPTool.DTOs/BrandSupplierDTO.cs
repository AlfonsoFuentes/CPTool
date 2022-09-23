using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{

    public class BrandSupplierDTO : AuditableEntityDTO, IMapFrom<BrandSupplier>
    {

        public int? SupplierId => SupplierDTO?.Id;
        public SupplierDTO? SupplierDTO { get; set; } = new();
       

        public int? BrandId => BrandDTO?.Id;
        public BrandDTO? BrandDTO { get; set; } = new();


    }

}
