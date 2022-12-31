using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ControlLoops.Commands.Delete
{
    public class DeleteControlLoopCommand : IRequest<DeleteControlLoopCommandResponse>
    {
        public int Id { get; set; }
    }
}
