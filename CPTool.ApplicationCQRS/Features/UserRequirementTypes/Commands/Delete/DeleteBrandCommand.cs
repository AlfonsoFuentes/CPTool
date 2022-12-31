using MediatR;

namespace CPTool.ApplicationCQRSFeatures.UserRequirementTypes.Commands.Delete
{
    public class DeleteUserRequirementTypeCommand : IRequest<DeleteUserRequirementTypeCommandResponse>
    {
        public int Id { get; set; }
    }
}
