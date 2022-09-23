



namespace CPTool.DTOS
{
   
    
    public class ChapterDTO : AuditableEntityDTO, IMapFrom<Chapter>
    {
        public ChapterDTO()
        {

        }
        public List<MWOItemDTO>? MWOItemDTOs { get; set; } = new();
        public string? Letter { get; set; } = "";
        public string LetterName => $"{Letter}-{Name}";
    }
}
