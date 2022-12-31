using MediatR;

namespace CPTool.ApplicationCQRS.Features.UserRequirements.Queries.ExportCSV
{
    public class GetUserRequirementsExportQuery : IRequest<UserRequirementExportFileVm>
    {
    }
}
