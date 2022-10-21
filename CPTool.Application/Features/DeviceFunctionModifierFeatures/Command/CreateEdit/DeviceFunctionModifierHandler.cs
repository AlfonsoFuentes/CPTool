namespace CPTool.Application.Features.DeviceFunctionModifierFeatures.CreateEdit
{
    internal class DeviceFunctionModifierHandler : AddEditBaseHandler<AddDeviceFunctionModifier, EditDeviceFunctionModifier, DeviceFunctionModifier>,
         IRequestHandler<EditDeviceFunctionModifier, Result<int>>
    {


        public DeviceFunctionModifierHandler(IUnitOfWork unitofwork, IMapper mapper, ILogger<EditDeviceFunctionModifier> logger)
            : base(unitofwork, mapper,  logger)
        {

        }


    }
}
