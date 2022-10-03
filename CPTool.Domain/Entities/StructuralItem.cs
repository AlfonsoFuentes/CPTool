namespace CPTool.Domain.Entities
{
    public class StructuralItem  : BaseDomainModel
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;

    }





}
