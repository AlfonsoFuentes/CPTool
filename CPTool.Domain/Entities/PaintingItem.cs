namespace CPTool.Domain.Entities
{
    public class PaintingItem  : BaseDomainModel
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
