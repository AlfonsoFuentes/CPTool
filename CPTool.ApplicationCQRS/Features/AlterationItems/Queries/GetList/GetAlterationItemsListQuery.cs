using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.AlterationItems.Queries.GetList
{
    public class GetAlterationItemsListQuery : IRequest<List<CommandAlterationItem>>
    {

    }
}
