

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class TestingItemDTO : AuditableEntityDTO, IMapFrom<TestingItem>
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();
    }





}
