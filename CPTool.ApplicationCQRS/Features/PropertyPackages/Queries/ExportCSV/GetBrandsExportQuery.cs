using MediatR;

namespace CPTool.ApplicationCQRS.Features.PropertyPackages.Queries.ExportCSV
{
    public class GetPropertyPackagesExportQuery : IRequest<PropertyPackageExportFileVm>
    {
    }
}
