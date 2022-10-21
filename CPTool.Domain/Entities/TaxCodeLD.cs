namespace CPTool.Domain.Entities
{
    public class TaxCodeLD  : BaseDomainModel
    {
        [ForeignKey("TaxCodeLDId")]
        public ICollection<Supplier> Suppliers { get; set; } = null!;
    }
}
