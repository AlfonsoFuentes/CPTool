



using CPTool.Application.Features.MeasuredVariableModifierFeatures.CreateEdit;

namespace CPTool.Application.Features.MeasuredVariableModifierFeatures.Mapping
{
    internal class MeasuredVariableModifierMapping : Profile
    {
        public MeasuredVariableModifierMapping()
        {
            CreateMap<MeasuredVariableModifier, EditMeasuredVariableModifier>();
            CreateMap<EditMeasuredVariableModifier, AddMeasuredVariableModifier>();
            CreateMap<EditMeasuredVariableModifier, MeasuredVariableModifier>();
            CreateMap<AddMeasuredVariableModifier, MeasuredVariableModifier>();
        }
    }
}
