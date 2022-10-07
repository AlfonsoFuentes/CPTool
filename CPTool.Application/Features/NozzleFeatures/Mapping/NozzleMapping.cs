



using CPTool.Application.Features.NozzleFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.NozzleFeatures.Mapping
{
    internal class NozzleMapping : Profile
    {
        public NozzleMapping()
        {
            CreateMap<Nozzle, AddEditNozzleCommand>()
                .ForMember(dest => dest.StartPipingItemsCommand, act => { act.PreCondition(src => (src.StartPipingItems != null)); act.MapFrom(src => src.StartPipingItems); })
                .ForMember(dest => dest.FinishPipingItemsCommand, act => { act.PreCondition(src => (src.FinishPipingItems != null)); act.MapFrom(src => src.FinishPipingItems); })
                .ForMember(dest => dest.PipeClassCommand, act => { act.PreCondition(src => (src.PipeClass != null)); act.MapFrom(src => src.PipeClass); })
                .ForMember(dest => dest.PipeDiameterCommand, act => { act.PreCondition(src => (src.PipeDiameter != null)); act.MapFrom(src => src.PipeDiameter); })
                .ForMember(dest => dest.ConnectionTypeCommand, act => { act.PreCondition(src => (src.ConnectionType != null)); act.MapFrom(src => src.ConnectionType); })
                .ForMember(dest => dest.GasketCommand, act => { act.PreCondition(src => (src.Gasket != null)); act.MapFrom(src => src.Gasket); })
                .ForMember(dest => dest.MaterialCommand, act => { act.PreCondition(src => (src.Material != null)); act.MapFrom(src => src.Material); })
                .ForMember(dest => dest.PipeAccesoryCommand, act => { act.PreCondition(src => (src.PipeAccesory != null)); act.MapFrom(src => src.PipeAccesory); })
                .ForMember(dest => dest.EquipmentItemCommand, act => { act.PreCondition(src => (src.EquipmentItem != null)); act.MapFrom(src => src.EquipmentItem); })
                .ForMember(dest => dest.InstrumentItemCommand, act => { act.PreCondition(src => (src.InstrumentItem != null)); act.MapFrom(src => src.InstrumentItem); })
                .ForMember(dest => dest.PipingItemCommand, act => { act.PreCondition(src => (src.PipingItem != null)); act.MapFrom(src => src.PipingItem); });
           

            CreateMap<AddEditNozzleCommand, Nozzle>();
        }
    }
}
