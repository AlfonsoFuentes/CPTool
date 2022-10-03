

using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
    
    public class ContingencyItemDTO : AuditableEntityDTO, IMapFrom<ContingencyItem>
    {
        public List<MWOItemDTO>? MWOItemsDTO { get; set; } = new();
    }





}
