using CPTool.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPTool.DTOS
{
   
    public class EquipmentTypeSubDTO : AuditableEntityDTO, IMapFrom<EquipmentTypeSub>
    {

       
        public EquipmentTypeDTO? EquipmentTypeDTO { get => (Master as EquipmentTypeDTO)!; set => Master = value; } 
        public string? TagLetter { get; set; } = "";
        public  List<EquipmentItemDTO> EquipmentItemsDTO { get; set; } = new();



    }
    
}
