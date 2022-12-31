using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Wires.Commands.Delete
{
    public class DeleteWireCommand : IRequest<DeleteWireCommandResponse>
    {
        public int Id { get; set; }
    }
}
