

namespace CPTool.Entities
{
    public class ProcessFluid : AuditableEntity
    {
        public ICollection<EquipmentItem>? EquipmentItems { get; set; } = null!;
        public ICollection<InstrumentItem>? InstrumentItems { get; set; } = null!;
        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        public ICollection<ProcessCondition>? ProcessCondition { get; set; } = null!;
    }

}
