namespace CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit
{
    internal class DeviceFunctionHandler : AddEditBaseHandler<AddDeviceFunction,EditDeviceFunction, DeviceFunction>, IRequestHandler<EditDeviceFunction, Result<int>>
    {


        public DeviceFunctionHandler(IUnitOfWork unitofwork, IMapper mapper,  ILogger<EditDeviceFunction> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}
