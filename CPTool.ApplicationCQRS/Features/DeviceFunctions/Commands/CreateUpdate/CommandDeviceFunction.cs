using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate
{
    public class CommandDeviceFunction : CommandBase, IRequest<DeviceFunctionCommandResponse>
    {


        public string? TagLetter { get; set; } = string.Empty;

    }

}
