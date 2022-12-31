using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate
{
    public class UserRequirementTypeCommandResponse : BaseResponse
    {
        public UserRequirementTypeCommandResponse() : base()
        {

        }

        public CommandUserRequirementType? UserRequirementTypeObject { get; set; }
    }
}