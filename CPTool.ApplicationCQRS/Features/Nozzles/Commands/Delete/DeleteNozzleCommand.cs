using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Nozzles.Commands.Delete
{
    public class DeleteNozzleCommand : IRequest<DeleteNozzleCommandResponse>
    {
        public int Id { get; set; }
    }
}
