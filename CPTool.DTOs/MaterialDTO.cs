

namespace CPTool.DTOS
{
    
    public class MaterialDTO  :AuditableEntityDTO, IMapFrom<Material>
    {
        public MaterialDTO()
        {

        }
        public string? Abbreviation { get; set; }


        public List<EquipmentItemDTO>? EquipmentItemInnerMaterialDTOs { get; set; } =null;
        public List<EquipmentItemDTO>? EquipmentItemOuterMaterialDTOs { get; set; } = null;

        public List<InstrumentItemDTO>? InstrumentItemInnerMaterialDTOs { get; set; } = null;
        public List<InstrumentItemDTO>? InstrumentItemOuterMaterialDTOs { get; set; } = null;

        public List<PipingItemDTO>? PipingItemsDTO { get; set; } = null;

       
        public List<NozzleDTO>? NozzlesDTO { get; set; } = null;
    }
}
