namespace CPTool.Domain.Entities
{
    public class TaxCodeLD  : BaseDomainModel
    {
        public ICollection<Supplier> Suppliers { get; set; } = null!;
    }
}
