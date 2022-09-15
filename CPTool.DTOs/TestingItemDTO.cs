

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class TestingItemDTO : AuditableEntityDTO
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();
    }





}
