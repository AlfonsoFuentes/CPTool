



using CPTool.Application.Features.ProcessFluidFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ProcessFluidFeatures.Mapping
{
    internal class ProcessFluidMapping : Profile
    {
        public ProcessFluidMapping()
        {
            CreateMap<ProcessFluid, AddEditProcessFluidCommand>()
                .ForMember(dest => dest.EquipmentItemsCommand, act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); })
                .ForMember(dest => dest.InstrumentItemsCommand, act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); })
                .ForMember(dest => dest.PipingItemsCommand, act => { act.PreCondition(src => (src.PipingItems != null)); act.MapFrom(src => src.PipingItems); });
           

            CreateMap<AddEditProcessFluidCommand, ProcessFluid>();
        }
    }
}
