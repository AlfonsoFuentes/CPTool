

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class StructuralItemDTO : AuditableEntityDTO, IMapFrom<StructuralItem>
    {
        public List<MWOItemDTO>? MWOItemsDTO { get; set; } = new();

    }





}
