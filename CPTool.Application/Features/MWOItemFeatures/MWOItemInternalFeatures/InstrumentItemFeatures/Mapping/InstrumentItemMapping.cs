using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.InstrumentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.InstrumentItemFeatures.Mapping
{
    internal class InstrumentItemMapping : Profile
    {
        public InstrumentItemMapping()
        {
            CreateMap<InstrumentItem, AddEditInstrumentItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => src.MWOItems != null); act.MapFrom(src => src.MWOItems); });
              


            CreateMap<AddEditInstrumentItemCommand, InstrumentItem>();
        }
    }

}
