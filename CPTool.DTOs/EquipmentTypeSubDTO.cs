using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
   
    public class EquipmentTypeSubDTO : AuditableEntityDTO
    {

        public int EquipmentTypeId => EquipmentTypeDTO.Id;
        public  EquipmentTypeDTO EquipmentTypeDTO { get => (Master as EquipmentTypeDTO)!; set => Master = value; } 
        public string? TagLetter { get; set; } = "";
        public virtual List<EquipmentItemDTO> EquipmentItemDTOs { get; set; } = new();



    }
    public class CreateEquipmentTypeSubDTO : EquipmentTypeSubDTO
    {

    }
}
