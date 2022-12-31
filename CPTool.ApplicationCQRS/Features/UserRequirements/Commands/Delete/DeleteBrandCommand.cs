using MediatR;

namespace CPTool.ApplicationCQRSFeatures.UserRequirements.Commands.Delete
{
    public class DeleteUserRequirementCommand : IRequest<DeleteUserRequirementCommandResponse>
    {
        public int Id { get; set; }
    }
}
