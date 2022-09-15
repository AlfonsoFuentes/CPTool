

namespace CPTool.DTOS
{
    
    public class MaterialDTO  :AuditableEntityDTO
    {
        public string? Abbreviation { get; set; }
      
        public  List<EquipmentItemDTO>? InnerMaterialsDTO { get; set; } = new();


        public  List<EquipmentItemDTO>? OuterMaterialsDTO { get; set; } = new();
    }
}
