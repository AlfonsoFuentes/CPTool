namespace CPTool.Domain.Entities
{
    public class EngineeringCostItem  : BaseDomainModel
    {
        [ForeignKey("EngineeringCostItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
