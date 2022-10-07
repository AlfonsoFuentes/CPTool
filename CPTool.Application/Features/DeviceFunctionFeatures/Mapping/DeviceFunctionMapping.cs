



using CPTool.Application.Features.DeviceFunctionFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.DeviceFunctionFeatures.Mapping
{
    internal class DeviceFunctionMapping : Profile
    {
        public DeviceFunctionMapping()
        {
            CreateMap<DeviceFunction, AddEditDeviceFunctionCommand>()
                .ForMember(dest => dest.InstrumentItemsCommand,
                act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); });
           

            CreateMap<AddEditDeviceFunctionCommand, DeviceFunction>();
        }
    }
}
