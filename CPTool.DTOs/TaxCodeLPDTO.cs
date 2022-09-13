using CPTool.Entities;

namespace CPTool.DTOS
{
    public class TaxCodeLPDTO : AuditableEntityDTO
    {
        public virtual List<Supplier> SuppliersDTO { get; set; } = null!;
    }
}
