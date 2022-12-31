using CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ContingencyItems.Queries.GetList
{
    public class GetContingencyItemsListQuery : IRequest<List<CommandContingencyItem>>
    {

    }
}
