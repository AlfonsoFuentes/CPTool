namespace CPTool.Domain.Entities
{
    public class InsulationItem  : BaseDomainModel
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
