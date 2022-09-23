

namespace CPTool.Entities
{
    public class PipeClass : AuditableEntity
    {

        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
    }

}
