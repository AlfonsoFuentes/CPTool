

namespace CPTool.Entities
{
    public class MWOType : AuditableEntity
    {
        public virtual ICollection<MWO> MWOs { get; set; } = null!;
    }





}
