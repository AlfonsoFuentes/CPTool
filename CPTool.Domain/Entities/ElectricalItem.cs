namespace CPTool.Domain.Entities
{
    public class ElectricalItem  : AuditableEntity
    {
        [ForeignKey("ElectricalItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
