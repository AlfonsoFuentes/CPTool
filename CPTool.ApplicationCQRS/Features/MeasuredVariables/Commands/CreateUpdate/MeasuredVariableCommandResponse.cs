using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate
{
    public class MeasuredVariableCommandResponse : BaseResponse<CommandMeasuredVariable>
    {
        public MeasuredVariableCommandResponse() : base()
        {

        }

    }
}