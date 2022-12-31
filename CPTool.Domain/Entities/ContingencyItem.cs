namespace CPTool.Domain.Entities
{
    public class ContingencyItem  : AuditableEntity
    {
        [ForeignKey("ContingencyItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
