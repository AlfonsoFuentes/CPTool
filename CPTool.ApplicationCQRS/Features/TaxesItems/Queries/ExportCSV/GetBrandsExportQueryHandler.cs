using AutoMapper;
using CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.TaxesItems.Queries.ExportCSV
{
    public class GetTaxesItemsExportQueryHandler : IRequestHandler<GetTaxesItemsExportQuery, TaxesItemExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetTaxesItemsExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<TaxesItemExportFileVm> Handle(GetTaxesItemsExportQuery request, CancellationToken cancellationToken)
        {
            var allTaxesItems = _mapper.Map<List<CommandTaxesItem>>((await _UnitOfWork.RepositoryTaxesItem.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allTaxesItems);

            var eventExportFileDto = new TaxesItemExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
