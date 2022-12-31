using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PaintingItems.Commands.Delete
{
    public class DeletePaintingItemCommand : IRequest<DeletePaintingItemCommandResponse>
    {
        public int Id { get; set; }
    }
}
