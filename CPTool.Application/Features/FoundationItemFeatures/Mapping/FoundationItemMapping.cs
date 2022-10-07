



using CPTool.Application.Features.FoundationItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.FoundationItemFeatures.Mapping
{
    internal class FoundationItemMapping : Profile
    {
        public FoundationItemMapping()
        {
            CreateMap<FoundationItem, AddEditFoundationItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
           

            CreateMap<AddEditFoundationItemCommand, FoundationItem>();
        }
    }
}
