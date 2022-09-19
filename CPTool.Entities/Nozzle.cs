

namespace CPTool.Entities
{
    public class Nozzle : AuditableEntity
    {
        [ForeignKey("NozzleStartId")]
        public ICollection<PipingItem>? StartPipingItems { get; set; } = null!;
        [ForeignKey("NozzleFinishId")]
        public ICollection<PipingItem>? FinishPipingItems { get; set; } = null!;

        public int? PipeClassId { get; set; }
        public PipeClass? PipeClass { get; set; }

        public int? PipeDiameterId { get; set; }
        public PipeDiameter? PipeDiameter { get; set; }
        public int? ConnectionTypeId { get; set; }
        public ConnectionType? ConnectionType { get; set; }
        public int? GasketId { get; set; }
        public Gasket? Gasket { get; set; }
        public int? MaterialID { get; set; }
        public Material? Material { get; set; }

        public StreamType StreamType { get; set; }

        public PipeAccesory? PipeAccesory { get; set; }
        public int? PipeAccesoryId { get; set; }

        public int? EquipmentItemId { get; set; }
        public EquipmentItem? EquipmentItem { get; set; }
        public int? InstrumentItemId { get; set; }
        public InstrumentItem? InstrumentItem { get; set; }

        public int? PipingItemId { get; set; }
        public PipingItem? PipingItem { get; set; }
    }

}
