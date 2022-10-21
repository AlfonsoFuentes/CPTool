namespace CPTool.Domain.Entities
{
    public class StructuralItem  : BaseDomainModel
    {
        [ForeignKey("StructuralItemId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;

    }





}
