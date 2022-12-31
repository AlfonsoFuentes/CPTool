namespace CPTool.Domain.Entities
{
    public class TaxCodeLP  : AuditableEntity
    {
        [ForeignKey("TaxCodeLPId")]
        public ICollection<Supplier> Suppliers { get; set; } = null!;
    }
}
