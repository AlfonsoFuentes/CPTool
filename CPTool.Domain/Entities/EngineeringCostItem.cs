namespace CPTool.Domain.Entities
{
    public class EngineeringCostItem  : AuditableEntity
    {
        [ForeignKey("EngineeringCostItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
