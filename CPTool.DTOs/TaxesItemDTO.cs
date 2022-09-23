

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class TaxesItemDTO : AuditableEntityDTO, IMapFrom<TaxesItem>
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();
    }





}
