using CPTool.Entities;

namespace CPTool.DTOS
{
    public class TaxCodeLDDTO : AuditableEntityDTO
    {
        public virtual List<Supplier> SuppliersDTO { get; set; } = null!;
    }
}
