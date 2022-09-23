

namespace CPTool.Entities
{
    public class ContingencyItem : AuditableEntity
    {
        public  ICollection<MWOItem> MWOItems { get; set; } = null!;
    }





}
