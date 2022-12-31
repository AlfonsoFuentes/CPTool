namespace CPTool.Domain.Entities
{
    public class SignalType: AuditableEntity
    {
        [ForeignKey("SignalTypeId")]
        public ICollection<Signal>? Signals { get; set; } = null!;
    }

}
