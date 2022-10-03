namespace CPTool.Domain.Entities
{
    public class TaxesItem  : BaseDomainModel
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }

}
