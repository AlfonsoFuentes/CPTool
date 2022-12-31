namespace CPTool.Domain.Entities
{
    public class Wire : AuditableEntity
    {
        [ForeignKey("WireId")]
        public ICollection<Signal>? Signals { get; set; } = null!;
    }

}
