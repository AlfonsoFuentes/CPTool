using MediatR;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLPs.Queries.ExportCSV
{
    public class GetTaxCodeLPsExportQuery : IRequest<TaxCodeLPExportFileVm>
    {
    }
}
