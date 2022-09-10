using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
   
    public class EquipmentTypeSubDTO : AuditableEntityDTO
    {
      
      
        public virtual EquipmentTypeDTO? EquipmentTypeDTO { get; set; }
        public string? TagLetter { get; set; } = "";
        public virtual ICollection<EquipmentItemDTO> EquipmentItemDTOs { get; set; }

    }
}
