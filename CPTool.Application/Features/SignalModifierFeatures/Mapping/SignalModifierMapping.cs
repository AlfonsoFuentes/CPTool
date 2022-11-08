



using CPTool.Application.Features.SignalModifiersFeatures.CreateEdit;


namespace CPTool.Application.Features.SignalModifiersFeatures.Mapping
{
    internal class SignalModifierMapping : Profile
    {
        public SignalModifierMapping()
        {
            CreateMap<SignalModifier, EditSignalModifier>();
            CreateMap<AddSignalModifier, SignalModifier>();
            CreateMap<EditSignalModifier, SignalModifier>();
            CreateMap<EditSignalModifier, AddSignalModifier>();
        }
    }
}
