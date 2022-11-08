namespace CPTool.Domain.Entities
{
    public class SignalModifier : BaseDomainModel
    {
        [ForeignKey("SignalModifierId")]
        public ICollection<Signal>? Signals { get; set; } = null!;
    }
}
