

using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
    
    public class AlterationItemDTO : AuditableEntityDTO
    {
        public List<MWOItemDTO> MWOItemDTOs { get; set; } = new();
        public static string TableName = "Alteration";

    }





}
