using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Gaskets.Commands.Delete
{
    public class DeleteGasketCommand : IRequest<DeleteGasketCommandResponse>
    {
        public int Id { get; set; }
    }
}
