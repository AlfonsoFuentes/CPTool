using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Gaskets.Queries.GetList
{
    public class GetGasketsListQuery : IRequest<List<CommandGasket>>
    {

    }
}
