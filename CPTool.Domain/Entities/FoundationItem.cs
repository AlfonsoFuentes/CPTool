namespace CPTool.Domain.Entities
{
    public class FoundationItem  : AuditableEntity
    {
        [ForeignKey("FoundationItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;

    }





}
