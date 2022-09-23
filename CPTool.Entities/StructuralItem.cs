

namespace CPTool.Entities
{
    public class StructuralItem : AuditableEntity
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;

    }





}
