using CPTool.ApplicationCQRSResponses;
using FluentValidation.Results;

namespace CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate
{
    public class UserCommandResponse : BaseResponse<CommandUser>
    {
        public UserCommandResponse() : base()
        {

        }

       
    }
}