using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipeClasss.Commands.Delete
{
    public class DeletePipeClassCommand : IRequest<DeletePipeClassCommandResponse>
    {
        public int Id { get; set; }
    }
}
