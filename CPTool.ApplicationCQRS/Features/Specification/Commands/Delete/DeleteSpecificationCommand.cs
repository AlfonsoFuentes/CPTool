using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Specifications.Commands.Delete
{
    public class DeleteSpecificationCommand : IRequest<DeleteSpecificationCommandResponse>
    {
        public int Id { get; set; }
    }
}
