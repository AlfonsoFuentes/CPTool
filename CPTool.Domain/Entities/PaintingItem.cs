namespace CPTool.Domain.Entities
{
    public class PaintingItem  : BaseDomainModel
    {
        [ForeignKey("PaintingItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
