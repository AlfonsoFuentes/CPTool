namespace CPTool.Domain.Entities
{
    public class ContingencyItem  : BaseDomainModel
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
