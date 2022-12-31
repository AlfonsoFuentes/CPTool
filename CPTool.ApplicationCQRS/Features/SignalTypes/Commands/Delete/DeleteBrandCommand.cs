using MediatR;

namespace CPTool.ApplicationCQRSFeatures.SignalTypes.Commands.Delete
{
    public class DeleteSignalTypeCommand : IRequest<DeleteSignalTypeCommandResponse>
    {
        public int Id { get; set; }
    }
}
