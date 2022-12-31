using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate
{
    public class CommandMeasuredVariableModifier : CommandBase, IRequest<MeasuredVariableModifierCommandResponse>
    {


        public string? TagLetter { get; set; } = string.Empty;

    }

}
