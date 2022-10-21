namespace CPTool.Domain.Entities
{
    public class EHSItem  : BaseDomainModel
    {
        [ForeignKey("EHSItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
