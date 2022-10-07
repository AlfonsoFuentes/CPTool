



using CPTool.Application.Features.PipingItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipingItemFeatures.Mapping
{
    internal class PipingItemMapping : Profile
    {
        public PipingItemMapping()
        {
            CreateMap<PipingItem, AddEditPipingItemCommand>()
                .ForMember(dest => dest.NozzlesCommand, act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); })
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
                .ForMember(dest => dest.PipeAccesorysCommand, act => { act.PreCondition(src => (src.PipeAccesorys != null)); act.MapFrom(src => src.PipeAccesorys); })
                .ForMember(dest => dest.MaterialCommand, act => { act.PreCondition(src => (src.Material != null)); act.MapFrom(src => src.Material); })
                .ForMember(dest => dest.ProcessFluidCommand, act => { act.PreCondition(src => (src.ProcessFluid != null)); act.MapFrom(src => src.ProcessFluid); })
                .ForMember(dest => dest.DiameterCommand, act => { act.PreCondition(src => (src.Diameter != null)); act.MapFrom(src => src.Diameter); })
                .ForMember(dest => dest.NozzleStartCommand, act => { act.PreCondition(src => (src.NozzleStart != null)); act.MapFrom(src => src.NozzleStart); })
                .ForMember(dest => dest.NozzleFinishCommand, act => { act.PreCondition(src => (src.NozzleFinish != null)); act.MapFrom(src => src.NozzleFinish); })
                .ForMember(dest => dest.StartMWOItemCommand, act => { act.PreCondition(src => (src.StartMWOItem != null)); act.MapFrom(src => src.StartMWOItem); })
                .ForMember(dest => dest.FinishMWOItemCommand, act => { act.PreCondition(src => (src.FinishMWOItem != null)); act.MapFrom(src => src.FinishMWOItem); })
                .ForMember(dest => dest.PipeClassCommand, act => { act.PreCondition(src => (src.PipeClass != null)); act.MapFrom(src => src.PipeClass); });
           

            CreateMap<AddEditPipingItemCommand, PipingItem>();
        }
    }
}
