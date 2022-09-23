using CPTool.Entities;

namespace CPTool.DTOS
{
    public class TaxCodeLPDTO : AuditableEntityDTO, IMapFrom<TaxCodeLP>
    {
        public  List<Supplier>? SuppliersDTO { get; set; } = new();
    }
}
