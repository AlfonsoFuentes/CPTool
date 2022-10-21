namespace CPTool.Domain.Entities
{
    public class Chapter  : BaseDomainModel
    {
        [ForeignKey("ChapterId")]
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
        public string? Letter { get; set; }
    }
}
