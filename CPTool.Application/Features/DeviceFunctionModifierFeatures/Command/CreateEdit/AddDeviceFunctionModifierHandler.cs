namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit
{
    internal class AddDeviceFunctionModifierHandler :AddBaseHandler<AddDeviceFunctionModifier, DeviceFunctionModifier>,
        IRequestHandler<AddDeviceFunctionModifier, Result<int>>
    {
       

        public AddDeviceFunctionModifierHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<AddDeviceFunctionModifier> logger) : base(unitofwork, mapper, emailService, logger)
        {

        }

     
    }
}
