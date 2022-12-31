global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Profiles
{
    internal class DeviceFunctionModifierMapping : Profile
    {
        public DeviceFunctionModifierMapping()
        {
            CreateMap<DeviceFunctionModifier, CommandDeviceFunctionModifier>();
            CreateMap<CommandDeviceFunctionModifier, DeviceFunctionModifier>();
            CreateMap<AddDeviceFunctionModifier, DeviceFunctionModifier>();
            CreateMap<CommandDeviceFunctionModifier, AddDeviceFunctionModifier>();
        }
    }
}
