using CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.TestingItems.Queries.GetList
{
    public class GetTestingItemsListQuery : IRequest<List<CommandTestingItem>>
    {

    }
}
