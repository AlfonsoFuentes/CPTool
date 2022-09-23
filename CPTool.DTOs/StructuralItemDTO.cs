

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class StructuralItemDTO : AuditableEntityDTO, IMapFrom<StructuralItem>
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();

    }





}
