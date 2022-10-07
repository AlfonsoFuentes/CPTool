



using CPTool.Application.Features.ContingencyItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ContingencyItemFeatures.Mapping
{
    internal class ContingencyItemMapping : Profile
    {
        public ContingencyItemMapping()
        {
            CreateMap<ContingencyItem, AddEditContingencyItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
           

            CreateMap<AddEditContingencyItemCommand, ContingencyItem>();
        }
    }
}
