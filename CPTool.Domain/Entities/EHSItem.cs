namespace CPTool.Domain.Entities
{
    public class EHSItem  : AuditableEntity
    {
        [ForeignKey("EHSItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
