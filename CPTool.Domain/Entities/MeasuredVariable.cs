namespace CPTool.Domain.Entities
{
    public class MeasuredVariable  : AuditableEntity
    {
        [ForeignKey("MeasuredVariableId")]
        public ICollection<Specification>? Specifications { get; set; }
        public string? TagLetter { get; set; }

        [ForeignKey("MeasuredVariableId")]
        public ICollection<MWOItem>? MWOItems { get; set; } = null!;
    }


}
