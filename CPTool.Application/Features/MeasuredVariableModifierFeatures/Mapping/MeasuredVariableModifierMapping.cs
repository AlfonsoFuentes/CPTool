



using CPTool.Application.Features.MeasuredVariableModifierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableModifierFeatures.Mapping
{
    internal class MeasuredVariableModifierMapping : Profile
    {
        public MeasuredVariableModifierMapping()
        {
            CreateMap<MeasuredVariableModifier, AddEditMeasuredVariableModifierCommand>()
                .ForMember(dest => dest.InstrumentItemsCommand,
                act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); });


            CreateMap<AddEditMeasuredVariableModifierCommand, MeasuredVariableModifier>();
        }
    }
}
