namespace CPTool.Domain.Entities
{
    public class ElectricalItem  : BaseDomainModel
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
