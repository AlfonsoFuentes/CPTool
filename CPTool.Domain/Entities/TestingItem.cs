namespace CPTool.Domain.Entities
{
    public class TestingItem  : BaseDomainModel
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
