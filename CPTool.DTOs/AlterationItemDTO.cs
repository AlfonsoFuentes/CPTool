

using CPTool.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CPTool.DTOS
{
    
    public class AlterationItemDTO : AuditableEntityDTO
    {
        public List<MWOItemDTO> MWOItemDTOs { get; set; } = new();

        [Required]
        public string CostCenter { get; set; } = ""!;
    }





}
