



using CPTool.Application.Features.MeasuredVariableFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableFeatures.Mapping
{
    internal class MeasuredVariableMapping : Profile
    {
        public MeasuredVariableMapping()
        {
            CreateMap<MeasuredVariable, AddEditMeasuredVariableCommand>()
                .ForMember(dest => dest.InstrumentItemsCommand, act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); });
           

            CreateMap<AddEditMeasuredVariableCommand, MeasuredVariable>();
        }
    }
}
