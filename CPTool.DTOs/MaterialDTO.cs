using CPTool.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    
    public class MaterialDTO  :AuditableEntityDTO
    {
        public string? Abbreviation { get; set; }
      
        public virtual List<EquipmentItemDTO> InnerMaterialsDTO { get; set; } = new();


        public virtual List<EquipmentItemDTO> OuterMaterialsDTO { get; set; } = new();
    }
}
