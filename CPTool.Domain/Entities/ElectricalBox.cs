namespace CPTool.Domain.Entities
{
    public class ElectricalBox : BaseDomainModel
    {
        [ForeignKey("ElectricalBoxId")]
        public ICollection<Signal>? Signals { get; set; } = null!;
    }

}
