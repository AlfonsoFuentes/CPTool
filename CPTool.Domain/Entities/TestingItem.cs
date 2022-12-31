namespace CPTool.Domain.Entities
{
    public class TestingItem  : AuditableEntity
    {
        [ForeignKey("TestingItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
