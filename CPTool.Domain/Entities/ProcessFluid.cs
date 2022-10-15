namespace CPTool.Domain.Entities
{
    public class ProcessFluid  : BaseDomainModel
    {
        
        [ForeignKey("ProcessFluidEquipmentId")]
        public ICollection<EquipmentItem>? EquipmentItems { get; set; } = null!;
        [ForeignKey("ProcessFluidInstrumentId")]
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        [ForeignKey("ProcessFluidPipingId")]
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
       
    }

}
