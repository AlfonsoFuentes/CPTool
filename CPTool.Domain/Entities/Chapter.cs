namespace CPTool.Domain.Entities
{
    public class Chapter  : BaseDomainModel
    {
        public ICollection<MWOItem> MWOItems { get; set; } = null!;
        public string? Letter { get; set; }
    }
}
