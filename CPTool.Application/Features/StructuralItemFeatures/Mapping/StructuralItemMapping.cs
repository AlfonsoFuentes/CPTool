



using CPTool.Application.Features.StructuralItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.StructuralItemFeatures.Mapping
{
    internal class StructuralItemMapping : Profile
    {
        public StructuralItemMapping()
        {
            CreateMap<StructuralItem, AddEditStructuralItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
           

            CreateMap<AddEditStructuralItemCommand, StructuralItem>();
        }
    }
}
