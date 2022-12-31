using CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PaintingItems.Queries.GetList
{
    public class GetPaintingItemsListQuery : IRequest<List<CommandPaintingItem>>
    {

    }
}
