

using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
   
    
    public class ChapterDTO : AuditableEntityDTO
    {
        public List<MWOItemDTO> MWOItemDTOs { get; set; }
        public string? Letter { get; set; } = "";
        public string LetterName => $"{Letter}-{Name}";
    }
}
