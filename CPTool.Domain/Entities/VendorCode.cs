namespace CPTool.Domain.Entities
{
    public class VendorCode  : BaseDomainModel
    {
        public ICollection<Supplier> Suppliers { get; set; } = null!;
    }
}
