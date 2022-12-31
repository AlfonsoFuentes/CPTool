namespace CPTool.Domain.Entities
{
    public class StructuralItem  : AuditableEntity
    {
        [ForeignKey("StructuralItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;

    }





}
