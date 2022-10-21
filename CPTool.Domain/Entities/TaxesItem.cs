namespace CPTool.Domain.Entities
{
    public class TaxesItem  : BaseDomainModel
    {
        [ForeignKey("TaxesItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }

}
