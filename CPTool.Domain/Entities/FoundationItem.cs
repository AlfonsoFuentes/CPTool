namespace CPTool.Domain.Entities
{
    public class FoundationItem  : BaseDomainModel
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;

    }





}
