





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.ChapterFeatures.CreateEdit
{
    public class AddChapter : AddCommand, IRequest<Result<int>>
    {
        public string LetterName=>$"{Letter}-{Name}";
        public string? Letter { get; set; }
       
    }
}
