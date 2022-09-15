

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class PipingItemDTO : AuditableEntityDTO
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();
    }





}
