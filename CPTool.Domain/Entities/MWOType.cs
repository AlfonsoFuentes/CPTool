namespace CPTool.Domain.Entities
{
    public class MWOType  : AuditableEntity
    {
        public  ICollection<MWO> MWOs { get; set; } = null!;
    }





}
