using AutoMapper;
using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLPs.Queries.ExportCSV
{
    public class GetTaxCodeLPsExportQueryHandler : IRequestHandler<GetTaxCodeLPsExportQuery, TaxCodeLPExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetTaxCodeLPsExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<TaxCodeLPExportFileVm> Handle(GetTaxCodeLPsExportQuery request, CancellationToken cancellationToken)
        {
            var allTaxCodeLPs = _mapper.Map<List<CommandTaxCodeLP>>((await _UnitOfWork.RepositoryTaxCodeLP.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allTaxCodeLPs);

            var eventExportFileDto = new TaxCodeLPExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
