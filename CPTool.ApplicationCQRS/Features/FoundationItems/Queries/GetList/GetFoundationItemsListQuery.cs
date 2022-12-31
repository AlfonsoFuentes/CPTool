using CPTool.ApplicationCQRS.Features.FoundationItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.FoundationItems.Queries.GetList
{
    public class GetFoundationItemsListQuery : IRequest<List<CommandFoundationItem>>
    {

    }
}
