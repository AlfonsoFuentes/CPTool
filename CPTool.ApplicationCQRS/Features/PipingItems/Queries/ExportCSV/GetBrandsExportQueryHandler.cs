using AutoMapper;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PipingItems.Queries.ExportCSV
{
    public class GetPipingItemsExportQueryHandler : IRequestHandler<GetPipingItemsExportQuery, PipingItemExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetPipingItemsExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<PipingItemExportFileVm> Handle(GetPipingItemsExportQuery request, CancellationToken cancellationToken)
        {
            var allPipingItems = _mapper.Map<List<CommandPipingItem>>((await _UnitOfWork.RepositoryPipingItem.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allPipingItems);

            var eventExportFileDto = new PipingItemExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
