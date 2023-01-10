using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PropertySpecifications.Commands.Delete
{
    public class DeletePropertySpecificationCommand : IRequest<DeletePropertySpecificationCommandResponse>
    {
        public int Id { get; set; }
    }
}
