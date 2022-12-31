using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Signals.Commands.Delete
{
    public class DeleteSignalCommand : IRequest<DeleteSignalCommandResponse>
    {
        public int Id { get; set; }
    }
}
