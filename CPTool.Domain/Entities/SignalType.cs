namespace CPTool.Domain.Entities
{
    public class SignalType: BaseDomainModel
    {
        [ForeignKey("SignalTypeId")]
        public ICollection<Signal>? Signals { get; set; } = null!;
    }

}
