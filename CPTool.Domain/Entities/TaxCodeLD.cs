namespace CPTool.Domain.Entities
{
    public class TaxCodeLD  : AuditableEntity
    {
        [ForeignKey("TaxCodeLDId")]
        public ICollection<Supplier> Suppliers { get; set; } = null!;
    }
}
