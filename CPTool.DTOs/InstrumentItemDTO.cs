

using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
    public static partial class IncludeExtension
    {
       
    }
    public class InstrumentItemDTO : AuditableEntityDTO
    {
        public List<MWOItemDTO> MWOItemDTOs { get; set; } = new();
    }





}
