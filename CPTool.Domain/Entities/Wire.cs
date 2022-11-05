namespace CPTool.Domain.Entities
{
    public class Wire : BaseDomainModel
    {
        [ForeignKey("WireId")]
        public ICollection<Signal>? Signals { get; set; } = null!;
    }

}
