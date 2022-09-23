

namespace CPTool.Entities
{
    public class EngineeringCostItem : AuditableEntity
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
