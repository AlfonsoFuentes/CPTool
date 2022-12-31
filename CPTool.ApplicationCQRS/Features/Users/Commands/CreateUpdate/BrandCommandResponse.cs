using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate
{
    public class UserCommandResponse : BaseResponse
    {
        public UserCommandResponse() : base()
        {

        }

        public CommandUser? UserObject { get; set; }
    }
}