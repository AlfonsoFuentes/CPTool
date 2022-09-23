

namespace CPTool.Entities
{
    public class ElectricalItem : AuditableEntity
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
