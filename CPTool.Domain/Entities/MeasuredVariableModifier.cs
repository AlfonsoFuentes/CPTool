namespace CPTool.Domain.Entities
{
    public class MeasuredVariableModifier  : AuditableEntity
    {
        [ForeignKey("MeasuredVariableModifierId")]
        public ICollection<Specification>? Specifications { get; set; }
        public string? TagLetter { get; set; }

        [ForeignKey("MeasuredVariableModifierId")]
        public ICollection<MWOItem>? MWOItems { get; set; } = null!;
    }


}
