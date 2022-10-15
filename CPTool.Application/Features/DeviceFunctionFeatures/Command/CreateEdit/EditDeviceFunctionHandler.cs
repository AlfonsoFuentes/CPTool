namespace CPTool.Application.Features.DeviceFunctionFeatures.CreateEdit
{
    internal class EditDeviceFunctionHandler : EditBaseHandler<EditDeviceFunction, DeviceFunction>, IRequestHandler<EditDeviceFunction, Result<int>>
    {


        public EditDeviceFunctionHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditDeviceFunction> logger)
            : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}
