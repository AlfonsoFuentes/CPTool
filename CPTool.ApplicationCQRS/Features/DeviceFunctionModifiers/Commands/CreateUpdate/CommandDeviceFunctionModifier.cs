using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate
{
    public class CommandDeviceFunctionModifier : CommandBase, IRequest<DeviceFunctionModifierCommandResponse>
    {


        public string? TagLetter { get; set; }

    }

}
