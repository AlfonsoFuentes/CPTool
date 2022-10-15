namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit
{
    internal class EditDeviceFunctionModifierHandler : EditBaseHandler<EditDeviceFunctionModifier, DeviceFunctionModifier>,
         IRequestHandler<EditDeviceFunctionModifier, Result<int>>
    {


        public EditDeviceFunctionModifierHandler(IUnitOfWork unitofwork, IMapper mapper, IEmailService emailService, ILogger<EditDeviceFunctionModifier> logger) : base(unitofwork, mapper, emailService, logger)
        {

        }


    }
}
