



using CPTool.Application.Features.PipeClassFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipeClassFeatures.Mapping
{
    internal class PipeClassMapping : Profile
    {
        public PipeClassMapping()
        {
            CreateMap<PipeClass, AddEditPipeClassCommand>()
                .ForMember(dest => dest.PipingItemsCommand, act => { act.PreCondition(src => (src.PipingItems != null)); act.MapFrom(src => src.PipingItems); })
                .ForMember(dest => dest.PipeDiametersCommand, act => { act.PreCondition(src => (src.PipeDiameters != null)); act.MapFrom(src => src.PipeDiameters); })
                .ForMember(dest => dest.NozzlesCommand, act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); });
           

            CreateMap<AddEditPipeClassCommand, PipeClass>();
        }
    }
}
