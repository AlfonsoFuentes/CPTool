using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PipingItems.Queries.GetList
{
    public class GetPipingItemsListQuery : IRequest<List<CommandPipingItem>>
    {

    }
}
