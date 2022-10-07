



using CPTool.Application.Features.GasketsFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.GasketsFeatures.Mapping
{
    internal class GasketMapping : Profile
    {
        public GasketMapping()
        {
            CreateMap<Gasket, AddEditGasketCommand>()
                .ForMember(dest => dest.NozzlesCommand, act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); })

                .ForMember(dest => dest.EquipmentItemsCommand, act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); })
            
                .ForMember(dest => dest.InstrumentItemsCommand, act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); });

            CreateMap<AddEditGasketCommand, Gasket>();
        }
    }
}
