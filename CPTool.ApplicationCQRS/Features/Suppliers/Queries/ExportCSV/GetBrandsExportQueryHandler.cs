using AutoMapper;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Suppliers.Queries.ExportCSV
{
    public class GetSuppliersExportQueryHandler : IRequestHandler<GetSuppliersExportQuery, SupplierExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetSuppliersExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<SupplierExportFileVm> Handle(GetSuppliersExportQuery request, CancellationToken cancellationToken)
        {
            var allSuppliers = _mapper.Map<List<CommandSupplier>>((await _UnitOfWork.RepositorySupplier.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allSuppliers);

            var eventExportFileDto = new SupplierExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
