using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipeAccesorys.Commands.Delete
{
    public class DeletePipeAccesoryCommand : IRequest<DeletePipeAccesoryCommandResponse>
    {
        public int Id { get; set; }
    }
}
