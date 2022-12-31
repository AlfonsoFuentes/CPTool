using MediatR;

namespace CPTool.ApplicationCQRS.Features.UserRequirementTypes.Queries.ExportCSV
{
    public class GetUserRequirementTypesExportQuery : IRequest<UserRequirementTypeExportFileVm>
    {
    }
}
