



using CPTool.Application.Features.InstrumentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.InstrumentItemFeatures.Mapping
{
    internal class InstrumentItemMapping : Profile
    {
        public InstrumentItemMapping()
        {
            CreateMap<InstrumentItem, EditInstrumentItem>();


            CreateMap<AddInstrumentItem, InstrumentItem>();
            CreateMap<EditInstrumentItem, InstrumentItem>();
            CreateMap<EditInstrumentItem, AddInstrumentItem>();
        }
    }
}
