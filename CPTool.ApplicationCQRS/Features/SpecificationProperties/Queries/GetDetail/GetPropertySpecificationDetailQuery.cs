using CPTool.ApplicationCQRS.Features.PropertySpecifications.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PropertySpecifications.Queries.GetDetail
{
    public class GetPropertySpecificationDetailQuery : IRequest<CommandPropertySpecification>
    {
        public int Id { get; set; }
    }
}
