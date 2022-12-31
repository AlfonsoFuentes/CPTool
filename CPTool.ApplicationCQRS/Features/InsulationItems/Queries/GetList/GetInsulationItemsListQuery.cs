using CPTool.ApplicationCQRS.Features.InsulationItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.InsulationItems.Queries.GetList
{
    public class GetInsulationItemsListQuery : IRequest<List<CommandInsulationItem>>
    {

    }
}
