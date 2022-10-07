



using CPTool.Application.Features.PipeAccesoryFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipeAccesoryFeatures.Mapping
{
    internal class PipeAccesoryMapping : Profile
    {
        public PipeAccesoryMapping()
        {
            CreateMap<PipeAccesory, AddEditPipeAccesoryCommand>()
                .ForMember(dest => dest.PipingItemCommand, act => { act.PreCondition(src => (src.PipingItem != null)); act.MapFrom(src => src.PipingItem); })
                .ForMember(dest => dest.ProcessConditionCommand, act => { act.PreCondition(src => (src.ProcessCondition != null)); act.MapFrom(src => src.ProcessCondition); })
                .ForMember(dest => dest.ProcessFluidCommand, act => { act.PreCondition(src => (src.ProcessFluid != null)); act.MapFrom(src => src.ProcessFluid); })
                .ForMember(dest => dest.FrictionCommand, act => { act.PreCondition(src => (src.Friction != null)); act.MapFrom(src => src.Friction); })
                .ForMember(dest => dest.ReynoldCommand, act => { act.PreCondition(src => (src.Reynold != null)); act.MapFrom(src => src.Reynold); })
                .ForMember(dest => dest.LevelInletCommand, act => { act.PreCondition(src => (src.LevelInlet != null)); act.MapFrom(src => src.LevelInlet); })
                .ForMember(dest => dest.LevelOutletCommand, act => { act.PreCondition(src => (src.LevelOutlet != null)); act.MapFrom(src => src.LevelOutlet); })
                .ForMember(dest => dest.FrictionDropPressureCommand, act => { act.PreCondition(src => (src.FrictionDropPressure != null)); act.MapFrom(src => src.FrictionDropPressure); })
                .ForMember(dest => dest.OverallDropPressureCommand, act => { act.PreCondition(src => (src.OverallDropPressure != null)); act.MapFrom(src => src.OverallDropPressure); })
                .ForMember(dest => dest.ElevationChangeCommand, act => { act.PreCondition(src => (src.ElevationChange != null)); act.MapFrom(src => src.ElevationChange); })
                .ForMember(dest => dest.NozzlesCommand, act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); });
           

            CreateMap<AddEditPipeAccesoryCommand, PipeAccesory>();
        }
    }
}
