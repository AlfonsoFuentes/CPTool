using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class NozzleDTO : AuditableEntityDTO
    {
       
        public List<PipingItemDTO>? StartPipingItemsDTO { get; set; } = new();
      
        public List<PipingItemDTO>? FinishPipingItemsDTO { get; set; } = new();

        public int? PipeClassId => PipeClassDTO?.Id;
        public PipeClassDTO? PipeClassDTO { get; set; }

        public int? PipeDiameterId => PipeDiameterDTO?.Id;
        public PipeDiameterDTO? PipeDiameterDTO { get; set; }
        public int? ConnectionTypeId => ConnectionTypeDTO?.Id;
        public ConnectionTypeDTO? ConnectionTypeDTO { get; set; }
        public int? GasketId => GasketDTO?.Id;
        public GasketDTO? GasketDTO { get; set; }
        public int? MaterialId => MaterialDTO?.Id;
        public MaterialDTO? MaterialDTO { get; set; }

        public StreamType StreamType { get; set; }

        public PipeAccesoryDTO? PipeAccesoryDTO { get; set; }
        public int? PipeAccesoryId => PipeAccesoryDTO?.Id;

        public int? EquipmentItemId => EquipmentItemDTO?.Id;
        public EquipmentItemDTO? EquipmentItemDTO { get; set; }
        public int? InstrumentItemId => InstrumentItemDTO?.Id;
        public InstrumentItemDTO? InstrumentItemDTO { get; set; }

        public int? PipingItemId => PipingItemDTO?.Id;
        public PipingItemDTO? PipingItemDTO { get; set; }
    }
}
