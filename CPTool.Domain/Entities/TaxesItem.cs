namespace CPTool.Domain.Entities
{
    public class TaxesItem  : AuditableEntity
    {
        [ForeignKey("TaxesItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }

}
