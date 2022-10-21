namespace CPTool.Domain.Entities
{
    public class TestingItem  : BaseDomainModel
    {
        [ForeignKey("TestingItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
