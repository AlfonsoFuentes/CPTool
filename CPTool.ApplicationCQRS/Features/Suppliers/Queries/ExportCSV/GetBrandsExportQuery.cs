using MediatR;

namespace CPTool.ApplicationCQRS.Features.Suppliers.Queries.ExportCSV
{
    public class GetSuppliersExportQuery : IRequest<SupplierExportFileVm>
    {
    }
}
