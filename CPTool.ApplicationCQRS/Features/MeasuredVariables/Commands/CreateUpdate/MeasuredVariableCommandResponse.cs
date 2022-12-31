using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate
{
    public class MeasuredVariableCommandResponse : BaseResponse
    {
        public MeasuredVariableCommandResponse() : base()
        {

        }

        public CommandMeasuredVariable? MeasuredVariableObject { get; set; }
    }
}