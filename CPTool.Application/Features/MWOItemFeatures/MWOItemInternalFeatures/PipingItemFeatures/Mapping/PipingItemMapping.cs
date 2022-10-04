using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.PipingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.PipingItemFeatures.Mapping
{
    internal class PipingItemMapping : Profile
    {
        public PipingItemMapping()
        {
            CreateMap<PipingItem, AddEditPipingItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => src.MWOItems != null); act.MapFrom(src => src.MWOItems); });
              


            CreateMap<AddEditPipingItemCommand, PipingItem>();
        }
    }

}
