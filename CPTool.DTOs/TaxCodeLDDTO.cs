using CPTool.Entities;

namespace CPTool.DTOS
{
    public class TaxCodeLDDTO : AuditableEntityDTO
    {
        public List<Supplier>? SuppliersDTO { get; set; } = new();
    }
}
