using CPTool.Entities;

namespace CPTool.DTOS
{
    public class TaxCodeLPDTO : AuditableEntityDTO
    {
        public  List<Supplier>? SuppliersDTO { get; set; } = new();
    }
}
