namespace CPTool.Domain.Entities
{
    public class TaxCodeLP  : BaseDomainModel
    {
        public ICollection<Supplier> Suppliers { get; set; } = null!;
    }
}
