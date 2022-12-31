using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate
{
    public class UserRequirementCommandResponse : BaseResponse
    {
        public UserRequirementCommandResponse() : base()
        {

        }

        public CommandUserRequirement? UserRequirementObject { get; set; }
    }
}