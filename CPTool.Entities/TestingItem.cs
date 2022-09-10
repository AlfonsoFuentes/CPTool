

namespace CPTool.Entities
{
    public class TestingItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
