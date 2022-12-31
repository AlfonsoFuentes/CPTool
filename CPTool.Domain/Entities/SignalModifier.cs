namespace CPTool.Domain.Entities
{
    public class SignalModifier : AuditableEntity
    {
        [ForeignKey("SignalModifierId")]
        public ICollection<Signal>? Signals { get; set; } = null!;
    }
}
