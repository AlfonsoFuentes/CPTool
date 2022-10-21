namespace CPTool.Domain.Entities
{
    public class ElectricalItem  : BaseDomainModel
    {
        [ForeignKey("ElectricalItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
