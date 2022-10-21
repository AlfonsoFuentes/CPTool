namespace CPTool.Domain.Entities
{
    public class FoundationItem  : BaseDomainModel
    {
        [ForeignKey("FoundationItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;

    }





}
