namespace CPTool.Domain.Entities
{
    public class PipeClass  : BaseDomainModel
    {

        public ICollection<PipingItem>? PipingItems { get; set; } = null!;
        public ICollection<Nozzle>? Nozzles { get; set; } = null!;
    }

}
