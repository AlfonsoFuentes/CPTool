namespace CPTool.Domain.Entities
{
    public class MWOType  : BaseDomainModel
    {
        public  ICollection<MWO> MWOs { get; set; } = null!;
    }





}
