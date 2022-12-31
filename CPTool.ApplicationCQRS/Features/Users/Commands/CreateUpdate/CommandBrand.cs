using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Users.Commands.CreateUpdate
{
    public class CommandUser : CommandBase, IRequest<UserCommandResponse>
    {


        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobilPhone { get; set; } = string.Empty;

    }

}
