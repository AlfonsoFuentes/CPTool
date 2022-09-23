

namespace CPTool.Entities
{
    public class FoundationItem : AuditableEntity
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;

    }





}
