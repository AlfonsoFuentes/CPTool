using CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PropertySpecifications.Queries.GetList
{
    public class GetPropertySpecificationsListQuery : IRequest<List<CommandPropertySpecification>>
    {
        public int MWOItemId { get; set; }
    }
}
