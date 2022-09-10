

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class PaintingItemDTO : AuditableEntityDTO
    {
        public List<MWOItemDTO> MWOItemDTOs { get; set; }
    }





}
