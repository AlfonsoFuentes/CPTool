using CPTool.ApplicationCQRS.Features.EHSItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.EHSItems.Queries.GetList
{
    public class GetEHSItemsListQuery : IRequest<List<CommandEHSItem>>
    {

    }
}
