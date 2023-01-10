using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate
{
    public class ProcessConditionCommandResponse : BaseResponse<CommandProcessCondition>
    {
        public ProcessConditionCommandResponse() : base()
        {

        }


    }
}