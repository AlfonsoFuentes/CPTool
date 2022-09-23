

using CPTool.Entities;
using CPTool.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CPTool.DTOS
{
    
    public class AlterationItemDTO : AuditableEntityDTO,  IMapFrom<AlterationItem>
    {
        public List<MWOItemDTO> MWOItemDTOs { get; set; } = new();

        [Required]
        public string CostCenter { get; set; } = ""!;
    }





}
