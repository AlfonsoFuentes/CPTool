

namespace CPTool.Entities
{
    public class InstrumentItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
