using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate
{
    public class DeviceFunctionCommandResponse : BaseResponse
    {
        public DeviceFunctionCommandResponse() : base()
        {

        }

        public CommandDeviceFunction? DeviceFunctionObject { get; set; }
    }
}