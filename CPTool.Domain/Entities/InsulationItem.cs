namespace CPTool.Domain.Entities
{
    public class InsulationItem  : BaseDomainModel
    {
        [ForeignKey("InsulationItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
