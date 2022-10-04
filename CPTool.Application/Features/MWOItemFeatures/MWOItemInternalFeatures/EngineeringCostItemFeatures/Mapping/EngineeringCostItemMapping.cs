using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.EngineeringCostItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.EngineeringCostItemFeatures.Mapping
{
    internal class EngineeringCostItemMapping : Profile
    {
        public EngineeringCostItemMapping()
        {
            CreateMap<EngineeringCostItem, AddEditEngineeringCostItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => src.MWOItems != null); act.MapFrom(src => src.MWOItems); });
              


            CreateMap<AddEditEngineeringCostItemCommand, EngineeringCostItem>();
        }
    }

}
