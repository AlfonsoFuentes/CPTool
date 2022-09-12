using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
   
    public class EquipmentTypeSubDTO : AuditableEntityDTO
    {

        public int EquipmentTypeId { get; set; }
        public  EquipmentTypeDTO EquipmentTypeDTO { get; set; } = new();
        public string? TagLetter { get; set; } = "";
        public virtual List<EquipmentItemDTO> EquipmentItemDTOs { get; set; } = new();

    }
    public class CreateEquipmentTypeSubDTO : EquipmentTypeSubDTO
    {

    }
}
