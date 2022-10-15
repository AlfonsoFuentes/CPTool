




using CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.Mapping
{
    internal class DeviceFunctionModifierMapping : Profile
    {
        public DeviceFunctionModifierMapping()
        {
            CreateMap<DeviceFunctionModifier, EditDeviceFunctionModifier>();


            CreateMap<EditDeviceFunctionModifier, DeviceFunctionModifier>();
            CreateMap<AddDeviceFunctionModifier, DeviceFunctionModifier>();
        }
    }
}
