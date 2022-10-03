

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class TaxesItemDTO : AuditableEntityDTO, IMapFrom<TaxesItem>
    {
        public List<MWOItemDTO>? MWOItemsDTO { get; set; } = new();
    }





}
