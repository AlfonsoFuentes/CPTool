namespace CPTool.Domain.Entities
{
    public class FieldLocation : AuditableEntity
    {
        [ForeignKey("FieldLocationId")]
        public ICollection<Signal>? Signals { get; set; } = null!;
    }

}
