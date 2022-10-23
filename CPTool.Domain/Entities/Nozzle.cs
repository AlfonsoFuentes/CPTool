namespace CPTool.Domain.Entities
{
    public class Nozzle  : BaseDomainModel
    {
        [ForeignKey("NozzleStartId")]
        public ICollection<PipingItem>? StartPipingItems { get; set; } = null!;
        [ForeignKey("NozzleFinishId")]
        public ICollection<PipingItem>? FinishPipingItems { get; set; } = null!;

        public int? ConnectedToId { get; set; }
        public MWOItem? ConnectedTo { get; set; }

        public int? nPipeClassId { get; set; }
        public PipeClass? nPipeClass { get; set; }

        public int? PipeDiameterId { get; set; }
        public PipeDiameter? PipeDiameter { get; set; }
        public int? ConnectionTypeId { get; set; }
        public ConnectionType? ConnectionType { get; set; }
        public int? nGasketId { get; set; }
        public Gasket? nGasket { get; set; }
        public int? nMaterialId { get; set; }
        public Material? nMaterial { get; set; }

        public StreamType StreamType { get; set; }

        public PipeAccesory? PipeAccesory { get; set; }
        public int? PipeAccesoryId { get; set; }

        public int? EquipmentItemId { get; set; }
        public EquipmentItem? EquipmentItem { get; set; }
        public int? InstrumentItemId { get; set; }
        public InstrumentItem? InstrumentItem { get; set; }

        public int? PipingItemId { get; set; }
        public PipingItem? PipingItem { get; set; }
        public int Order { get; set; }
    }

}
