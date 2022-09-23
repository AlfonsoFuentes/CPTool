using CPTool.Entities;

namespace CPTool.DTOS
{
    public class VendorCodeDTO : AuditableEntityDTO, IMapFrom<VendorCode>
    {
        public  List<Supplier>?    SuppliersDTO { get; set; } = new();
    }
}
