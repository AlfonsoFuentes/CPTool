using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public  class MaterialsGroupDTO:AuditableEntityDTO
    {
        public List<EquipmentItemDTO> EquipmentItemDTOs { get; set; } = new();
        public List<InstrumentItemDTO> InstrumentItemDTOs { get; set; } = new();
        public GasketDTO? GasketDTO { get; set; } = new();
        public MaterialDTO? InnerMaterialDTO { get; set; } = new();
        public MaterialDTO? OuterMaterialDTO { get; set; } = new();
        public int? GasketId => GasketDTO?.Id == 0 ? null : GasketDTO?.Id;
        public int? InnerMaterialId => InnerMaterialDTO?.Id == 0 ? null : InnerMaterialDTO?.Id;
        public int? OuterMaterialId => OuterMaterialDTO?.Id == 0 ? null : OuterMaterialDTO?.Id;

        
    }
}
