namespace CPTool.Domain.Entities
{
    public class ProcessFluid  : BaseDomainModel
    {
        
        [ForeignKey("eProcessFluidId")]
        public ICollection<EquipmentItem>? EquipmentItems { get; set; } = null!;
        [ForeignKey("iProcessFluidId")]
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        [ForeignKey("pProcessFluidId")]
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        [ForeignKey("paProcessFluidId")]
        public ICollection<PipeAccesory>? PipeAccesorys { get; set; } = null!;
        public string TagLetter { get; set; } = "";
    }

}
