using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate
{
    public class ProcessConditionCommandResponse : BaseResponse
    {
        public ProcessConditionCommandResponse() : base()
        {

        }

        public CommandProcessCondition? ProcessConditionObject { get; set; }
    }
}