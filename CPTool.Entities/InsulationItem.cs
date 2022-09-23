

namespace CPTool.Entities
{
    public class InsulationItem : AuditableEntity
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
