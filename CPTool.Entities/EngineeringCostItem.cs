

namespace CPTool.Entities
{
    public class EngineeringCostItem : AuditableEntity
    {
        public virtual ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
