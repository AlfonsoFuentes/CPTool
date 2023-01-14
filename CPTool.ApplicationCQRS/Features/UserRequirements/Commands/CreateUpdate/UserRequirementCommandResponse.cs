using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate
{
    public class UserRequirementCommandResponse : BaseResponse<CommandUserRequirement>
    {
        public UserRequirementCommandResponse() : base()
        {

        }
    }
}