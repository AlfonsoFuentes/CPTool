

using CPTool.Entities;

namespace CPTool.DTOS
{
    public class StructuralItemDTO : AuditableEntityDTO
    {
        public List<MWOItemDTO> MWOItemDTOs { get; set; } = new();

    }





}
