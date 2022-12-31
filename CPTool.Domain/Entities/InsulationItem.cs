namespace CPTool.Domain.Entities
{
    public class InsulationItem  : AuditableEntity
    {
        [ForeignKey("InsulationItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
