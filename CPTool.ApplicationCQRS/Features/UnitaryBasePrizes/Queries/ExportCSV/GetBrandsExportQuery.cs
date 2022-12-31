using MediatR;

namespace CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Queries.ExportCSV
{
    public class GetUnitaryBasePrizesExportQuery : IRequest<UnitaryBasePrizeExportFileVm>
    {
    }
}
