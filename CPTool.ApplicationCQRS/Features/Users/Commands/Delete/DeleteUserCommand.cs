using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<DeleteUserCommandResponse>
    {
        public int Id { get; set; }
    }
}
