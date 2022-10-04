using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.StructuralItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.StructuralItemFeatures.Mapping
{
    internal class StructuralItemMapping : Profile
    {
        public StructuralItemMapping()
        {
            CreateMap<StructuralItem, AddEditStructuralItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => src.MWOItems != null); act.MapFrom(src => src.MWOItems); });
              


            CreateMap<AddEditStructuralItemCommand, StructuralItem>();
        }
    }

}
