using CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PaintingItems.Queries.GetDetail
{
    public class GetPaintingItemDetailQuery : IRequest<CommandPaintingItem>
    {
        public int Id { get; set; }
    }
}
