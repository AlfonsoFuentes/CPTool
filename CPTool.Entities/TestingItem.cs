

namespace CPTool.Entities
{
    public class TestingItem : AuditableEntity
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
