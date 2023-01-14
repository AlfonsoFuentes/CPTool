using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate
{
    public class UserRequirementTypeCommandResponse : BaseResponse<CommandUserRequirementType>
    {
        public UserRequirementTypeCommandResponse() : base()
        {

        }
    }
}