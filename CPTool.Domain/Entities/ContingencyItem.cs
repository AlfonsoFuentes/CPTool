namespace CPTool.Domain.Entities
{
    public class ContingencyItem  : BaseDomainModel
    {
        [ForeignKey("ContingencyItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
