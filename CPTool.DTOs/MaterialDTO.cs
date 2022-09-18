

namespace CPTool.DTOS
{
    
    public class MaterialDTO  :AuditableEntityDTO
    {
        public string? Abbreviation { get; set; }


        public List<MaterialsGroupDTO>? InnerMaterialDTOs { get; set; } = new();



        public List<MaterialsGroupDTO>? OuterMaterialDTOs { get; set; } = new();
    }
}
