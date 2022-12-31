using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.MeasuredVariableModifiers.Commands.CreateUpdate
{
    public class MeasuredVariableModifierCommandResponse : BaseResponse
    {
        public MeasuredVariableModifierCommandResponse() : base()
        {

        }

        public CommandMeasuredVariableModifier? MeasuredVariableModifierObject { get; set; }
    }
}