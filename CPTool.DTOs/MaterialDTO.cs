

namespace CPTool.DTOS
{
    
    public class MaterialDTO  :AuditableEntityDTO, IMapFrom<Material>
    {
        public MaterialDTO()
        {

        }
        public string? Abbreviation { get; set; }


        public List<EquipmentItemDTO>? EquipmentItemInnerMaterialsDTO { get; set; } =null;
        public List<EquipmentItemDTO>? EquipmentItemOuterMaterialsDTO { get; set; } = null;

        public List<InstrumentItemDTO>? InstrumentItemInnerMaterialsDTO { get; set; } = null;
        public List<InstrumentItemDTO>? InstrumentItemOuterMaterialsDTO { get; set; } = null;

        public List<PipingItemDTO>? PipingItemsDTO { get; set; } = null;

       
        public List<NozzleDTO>? NozzlesDTO { get; set; } = null;
    }
}
