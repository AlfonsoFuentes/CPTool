using AutoMapper;
using CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.TestingItems.Queries.ExportCSV
{
    public class GetTestingItemsExportQueryHandler : IRequestHandler<GetTestingItemsExportQuery, TestingItemExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetTestingItemsExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<TestingItemExportFileVm> Handle(GetTestingItemsExportQuery request, CancellationToken cancellationToken)
        {
            var allTestingItems = _mapper.Map<List<CommandTestingItem>>((await _UnitOfWork.RepositoryTestingItem.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allTestingItems);

            var eventExportFileDto = new TestingItemExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
