using AutoMapper;
using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLDs.Queries.ExportCSV
{
    public class GetTaxCodeLDsExportQueryHandler : IRequestHandler<GetTaxCodeLDsExportQuery, TaxCodeLDExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetTaxCodeLDsExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<TaxCodeLDExportFileVm> Handle(GetTaxCodeLDsExportQuery request, CancellationToken cancellationToken)
        {
            var allTaxCodeLDs = _mapper.Map<List<CommandTaxCodeLD>>((await _UnitOfWork.RepositoryTaxCodeLD.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allTaxCodeLDs);

            var eventExportFileDto = new TaxCodeLDExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
