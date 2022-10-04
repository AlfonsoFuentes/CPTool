



using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ChapterFeatures.Mapping
{
    internal class ChapterMapping : Profile
    {
        public ChapterMapping()
        {
            CreateMap<Chapter, AddEditChapterCommand>()
               ;
           

            CreateMap<AddEditChapterCommand, Chapter>();
        }
    }
}
