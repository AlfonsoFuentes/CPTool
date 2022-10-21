



using CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionFeatures.Mapping
{
    internal class DeviceFunctionMapping : Profile
    {
        public DeviceFunctionMapping()
        {
            CreateMap<DeviceFunction, EditDeviceFunction>();
           

            CreateMap<AddDeviceFunction, DeviceFunction>();
            CreateMap<EditDeviceFunction, DeviceFunction>();
            CreateMap<EditDeviceFunction, AddDeviceFunction>();
        }
    }
}
