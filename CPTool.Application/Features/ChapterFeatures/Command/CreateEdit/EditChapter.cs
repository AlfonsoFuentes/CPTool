

namespace CPTool.Application.Features.ChapterFeatures.CreateEdit
{
    public class EditChapter : EditCommand, IRequest<Result<int>>
    {
        [Report(Order = 3)]
        public string LetterName => $"{Letter}-{Name}";
        [Report(Order = 4)]
        public string? Letter { get; set; }
       
    }
}
