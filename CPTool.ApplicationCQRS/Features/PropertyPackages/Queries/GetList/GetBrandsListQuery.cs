using CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate;
using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PropertyPackages.Queries.GetList
{
    public class GetPropertyPackagesListQuery : IRequest<List<CommandPropertyPackage>>
    {

    }
}
