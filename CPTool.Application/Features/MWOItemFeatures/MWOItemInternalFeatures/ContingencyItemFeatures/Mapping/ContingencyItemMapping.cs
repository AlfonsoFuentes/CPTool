using CPTool.Application.Features.MWOItemFeatures.ContingencyItemFeatures.ContingencyItemFeatures.CreateEdit;


namespace CPTool.Application.Features.MWOItemFeatures.ContingencyItemFeatures.ContingencyItemFeatures.Mapping
{
    internal class ContingencyItemMapping : Profile
    {
        public ContingencyItemMapping()
        {
            CreateMap<ContingencyItem, AddEditContingencyItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => src.MWOItems != null); act.MapFrom(src => src.MWOItems); });
              


            CreateMap<AddEditContingencyItemCommand, ContingencyItem>();
        }
    }

}
