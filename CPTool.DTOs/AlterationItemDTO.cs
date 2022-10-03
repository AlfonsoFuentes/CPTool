

using CPTool.Entities;
using CPTool.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CPTool.DTOS
{
    
    public class AlterationItemDTO : AuditableEntityDTO
    {
        public List<MWOItemDTO> MWOItemsDTO { get; set; } = new();

        [Required]
        public string CostCenter { get; set; } = ""!;
    }





}
