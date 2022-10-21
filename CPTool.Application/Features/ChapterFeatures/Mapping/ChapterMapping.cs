



using CPTool.Application.Features.ChapterFeatures.CreateEdit;

namespace CPTool.Application.Features.ChapterFeatures.Mapping
{
    internal class ChapterMapping : Profile
    {
        public ChapterMapping()
        {
            CreateMap<Chapter, EditChapter>();
            CreateMap<AddChapter, Chapter>();
            CreateMap<EditChapter, Chapter>();
            CreateMap<EditChapter, AddChapter>();
        }
    }
}
