namespace CPTool.Domain.Entities
{
    public class EHSItem  : BaseDomainModel
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
