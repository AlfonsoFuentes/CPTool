



using CPTool.Application.Features.ChapterFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ChapterFeatures.Mapping
{
    internal class ChapterMapping : Profile
    {
        public ChapterMapping()
        {
            CreateMap<Chapter, AddEditChapterCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
           
           

            CreateMap<AddEditChapterCommand, Chapter>();
        }
    }
}
