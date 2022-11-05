namespace CPTool.Domain.Entities
{
    public class FieldLocation : BaseDomainModel
    {
        [ForeignKey("FieldLocationId")]
        public ICollection<Signal>? Signals { get; set; } = null!;
    }

}
