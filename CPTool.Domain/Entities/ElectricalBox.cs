namespace CPTool.Domain.Entities
{
    public class ElectricalBox : AuditableEntity
    {
        [ForeignKey("ElectricalBoxId")]
        public ICollection<Signal>? Signals { get; set; } = null!;
    }

}
