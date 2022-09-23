

using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
    
    public class ElectricalItemDTO : AuditableEntityDTO, IMapFrom<ElectricalItem>
    {
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();
    }





}
