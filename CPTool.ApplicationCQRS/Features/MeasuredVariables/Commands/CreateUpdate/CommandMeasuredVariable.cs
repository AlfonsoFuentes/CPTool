using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate
{
    public class CommandMeasuredVariable : CommandBase, IRequest<MeasuredVariableCommandResponse>
    {


        public string? TagLetter { get; set; } = string.Empty;

    }

}
