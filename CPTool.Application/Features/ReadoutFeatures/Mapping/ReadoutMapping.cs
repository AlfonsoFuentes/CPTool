



using CPTool.Application.Features.ReadoutFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ReadoutFeatures.Mapping
{
    internal class ReadoutMapping : Profile
    {
        public ReadoutMapping()
        {
            CreateMap<Readout, AddEditReadoutCommand>()
                .ForMember(dest => dest.InstrumentItemsCommand,
                act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); });


            CreateMap<AddEditReadoutCommand, Readout>();
        }
    }
}
