using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.AlterationItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.AlterationItemFeatures.Mapping
{
    internal class AlterationItemMapping : Profile
    {
        public AlterationItemMapping()
        {
            CreateMap<AlterationItem, AddEditAlterationItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => src.MWOItems != null); act.MapFrom(src => src.MWOItems); });
              


            CreateMap<AddEditAlterationItemCommand, AlterationItem>();
        }
    }

}
