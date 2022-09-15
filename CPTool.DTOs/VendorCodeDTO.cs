using CPTool.Entities;

namespace CPTool.DTOS
{
    public class VendorCodeDTO : AuditableEntityDTO
    {
        public  List<Supplier>?    SuppliersDTO { get; set; } = new();
    }
}
