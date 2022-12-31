using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate
{
    public class DeviceFunctionModifierCommandResponse : BaseResponse
    {
        public DeviceFunctionModifierCommandResponse() : base()
        {

        }

        public CommandDeviceFunctionModifier? DeviceFunctionModifierObject { get; set; }
    }
}