using CPTool.ApplicationCQRS.Features.Specifications.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Specifications.Queries.GetList
{
    public class GetSpecificationsListQuery : IRequest<List<CommandSpecification>>
    {

    }
}
