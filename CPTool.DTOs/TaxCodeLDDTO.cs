using CPTool.Entities;

namespace CPTool.DTOS
{
    public class TaxCodeLDDTO : AuditableEntityDTO, IMapFrom<TaxCodeLD>
    {
        public List<Supplier>? SuppliersDTO { get; set; } = new();
    }
}
