namespace CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit
{
    internal class AddDeviceFunctionHandler : AddBaseHandler<AddDeviceFunction, DeviceFunction>, IRequestHandler<AddDeviceFunction, Result<int>>
    {


        public AddDeviceFunctionHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddDeviceFunction> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}
