



namespace CPTool.DTOS
{
   
    
    public class ChapterDTO : AuditableEntityDTO, IMapFrom<Chapter>
    {
       
        public List<MWOItemDTO>? MWOItemsDTO { get; set; } = new();
        public string? Letter { get; set; } = "";
        public string LetterName => $"{Letter}-{Name}";
    }
}
