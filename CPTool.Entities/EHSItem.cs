

namespace CPTool.Entities
{
    public class EHSItem : AuditableEntity
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
