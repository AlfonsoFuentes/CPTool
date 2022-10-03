namespace CPTool.Domain.Entities
{
    public class ProcessFluid  : BaseDomainModel
    {
        public ICollection<EquipmentItem>? EquipmentItems { get; set; } = null!;
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        //public ICollection<ProcessCondition>? ProcessCondition { get; set; } = null!;
    }

}
