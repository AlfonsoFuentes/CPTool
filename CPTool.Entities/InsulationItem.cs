

namespace CPTool.Entities
{
    public class InsulationItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
