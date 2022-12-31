using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ConnectionTypes.Queries.GetList
{
    public class GetConnectionTypesListQuery : IRequest<List<CommandConnectionType>>
    {

    }
}
