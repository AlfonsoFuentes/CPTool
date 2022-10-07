




using CPTool.Application.Features.DeviceFunctionModifierFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.Mapping
{
    internal class DeviceFunctionModifierMapping : Profile
    {
        public DeviceFunctionModifierMapping()
        {
            CreateMap<DeviceFunctionModifier, AddEditDeviceFunctionModifierCommand>()
                .ForMember(dest => dest.InstrumentItemsCommand,
                act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); });


            CreateMap<AddEditDeviceFunctionModifierCommand, DeviceFunctionModifier>();
        }
    }
}
