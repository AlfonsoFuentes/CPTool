namespace CPTool.Domain.Entities
{
    public class TaxCodeLP  : BaseDomainModel
    {
        [ForeignKey("TaxCodeLPId")]
        public ICollection<Supplier> Suppliers { get; set; } = null!;
    }
}
