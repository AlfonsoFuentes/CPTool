

namespace CPTool.Entities
{
    public class ElectricalItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
