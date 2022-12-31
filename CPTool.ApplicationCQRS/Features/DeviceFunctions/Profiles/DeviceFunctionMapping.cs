global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctions.Profiles
{
    internal class DeviceFunctionMapping : Profile
    {
        public DeviceFunctionMapping()
        {
            CreateMap<DeviceFunction, CommandDeviceFunction>();
            CreateMap<CommandDeviceFunction, DeviceFunction>();
            CreateMap<AddDeviceFunction, DeviceFunction>();
            CreateMap<CommandDeviceFunction, AddDeviceFunction>();
        }
    }
}
