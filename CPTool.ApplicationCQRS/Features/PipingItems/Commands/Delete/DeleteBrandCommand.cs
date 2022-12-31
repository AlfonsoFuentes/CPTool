using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipingItems.Commands.Delete
{
    public class DeletePipingItemCommand : IRequest<DeletePipingItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
