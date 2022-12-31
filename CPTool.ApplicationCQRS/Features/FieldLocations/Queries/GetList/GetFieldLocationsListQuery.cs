using CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.FieldLocations.Queries.GetList
{
    public class GetFieldLocationsListQuery : IRequest<List<CommandFieldLocation>>
    {

    }
}
