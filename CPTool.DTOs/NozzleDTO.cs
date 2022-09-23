using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DTOS
{
    public class NozzleDTO : AuditableEntityDTO, IMapFrom<Nozzle>
    {
       
        public List<PipingItemDTO>? StartPipingItemsDTO { get; set; } = null!;

        public List<PipingItemDTO>? FinishPipingItemsDTO { get; set; } = null!;

        public int? PipeClassId => PipeClassDTO?.Id;
        public PipeClassDTO? PipeClassDTO { get; set; } = new();

        //public int? PipeDiameterId => PipeDiameterDTO?.Id;
        public PipeDiameterDTO? PipeDiameterDTO { get; set; } = new();
        //public int? ConnectionTypeId => ConnectionTypeDTO?.Id;
        public ConnectionTypeDTO? ConnectionTypeDTO { get; set; } = new();
        //public int? GasketId => GasketDTO?.Id;
        public GasketDTO? GasketDTO { get; set; } = new();
        //public int? MaterialId => MaterialDTO?.Id;
        public MaterialDTO? MaterialDTO { get; set; } = new();

        public StreamType StreamType { get; set; }

        public PipeAccesoryDTO? PipeAccesoryDTO { get; set; } = new();
        //public int? PipeAccesoryId => PipeAccesoryDTO?.Id;

        //public int? EquipmentItemId => EquipmentItemDTO?.Id;
        public EquipmentItemDTO? EquipmentItemDTO { get; set; } = null!;
        //public int? InstrumentItemId => InstrumentItemDTO?.Id;
        public InstrumentItemDTO? InstrumentItemDTO { get; set; } = null!;

        //public int? PipingItemId => PipingItemDTO?.Id;
        public PipingItemDTO? PipingItemDTO { get; set; } = null!;
    }
}
