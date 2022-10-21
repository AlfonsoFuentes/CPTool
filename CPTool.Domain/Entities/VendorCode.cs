namespace CPTool.Domain.Entities
{
    public class VendorCode  : BaseDomainModel
    {
        [ForeignKey("VendorCodeId")]
        public ICollection<Supplier> Suppliers { get; set; } = null!;
    }
}
