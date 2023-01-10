using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate
{
    public class DeviceFunctionCommandResponse : BaseResponse<CommandDeviceFunction>
    {
        public DeviceFunctionCommandResponse() : base()
        {

        }

    }
}