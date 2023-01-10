namespace CPTool.Domain.Entities
{
    public class PropertySpecification : AuditableEntity
    {

        public int? SpecificationId { get; set; }
        public Specification? Specification { get; set; }
        public string Value { get; set; } = string.Empty;

        public int? MWOItemId { get; set; }
        public MWOItem? MWOItem { get; set; }
    }
}
