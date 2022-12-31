using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ConnectionTypes.Commands.Delete
{
    public class DeleteConnectionTypeCommand : IRequest<DeleteConnectionTypeCommandResponse>
    {
        public int Id { get; set; }
    }
}
