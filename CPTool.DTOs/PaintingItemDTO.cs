

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class PaintingItemDTO : AuditableEntityDTO, IMapFrom<PaintingItem>
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();
    }





}
