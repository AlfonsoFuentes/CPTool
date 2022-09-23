

using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
   
    public class FoundationItemDTO : AuditableEntityDTO, IMapFrom<FoundationItem>
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();

    }





}
