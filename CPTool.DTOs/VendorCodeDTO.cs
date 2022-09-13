using CPTool.Entities;

namespace CPTool.DTOS
{
    public class VendorCodeDTO : AuditableEntityDTO
    {
        public virtual List<Supplier> SuppliersDTO { get; set; } = null!;
    }
}
