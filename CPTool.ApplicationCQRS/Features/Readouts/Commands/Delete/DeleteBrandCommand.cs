using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Readouts.Commands.Delete
{
    public class DeleteReadoutCommand : IRequest<DeleteReadoutCommandResponse>
    {
        public int Id { get; set; }
    }
}
