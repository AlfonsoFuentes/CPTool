using CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PropertyPackages.Queries.GetDetail
{
    public class GetPropertyPackageDetailQuery : IRequest<CommandPropertyPackage>
    {
        public int Id { get; set; }
    }
}
