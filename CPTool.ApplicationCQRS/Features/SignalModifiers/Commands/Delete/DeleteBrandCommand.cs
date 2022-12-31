using MediatR;

namespace CPTool.ApplicationCQRSFeatures.SignalModifiers.Commands.Delete
{
    public class DeleteSignalModifierCommand : IRequest<DeleteSignalModifierCommandResponse>
    {
        public int Id { get; set; }
    }
}
