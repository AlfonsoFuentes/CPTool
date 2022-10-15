





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.ChapterFeatures.CreateEdit
{
    public class EditChapter : EditCommand, IRequest<Result<int>>
    {
        public string LetterName => $"{Letter}-{Name}";
        public string? Letter { get; set; }
       
    }
}
