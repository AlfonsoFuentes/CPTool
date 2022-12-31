using MediatR;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLDs.Queries.ExportCSV
{
    public class GetTaxCodeLDsExportQuery : IRequest<TaxCodeLDExportFileVm>
    {
    }
}
