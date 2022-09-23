

using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
    
    public class ContingencyItemDTO : AuditableEntityDTO, IMapFrom<ContingencyItem>
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();
    }





}
