

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class PaintingItemDTO : AuditableEntityDTO, IMapFrom<PaintingItem>
    {
        public List<MWOItemDTO>? MWOItemsDTO { get; set; } = new();
    }





}
