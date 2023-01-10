using CPTool.ApplicationCQRS.Features.Specifications.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.Specifications.Queries.GetDetail
{
    public class GetSpecificationDetailQuery : IRequest<CommandSpecification>
    {
        public int Id { get; set; }
    }
}
