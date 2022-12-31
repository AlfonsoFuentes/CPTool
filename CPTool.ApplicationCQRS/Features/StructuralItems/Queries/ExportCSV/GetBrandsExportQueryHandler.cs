using AutoMapper;
using CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.StructuralItems.Queries.ExportCSV
{
    public class GetStructuralItemsExportQueryHandler : IRequestHandler<GetStructuralItemsExportQuery, StructuralItemExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetStructuralItemsExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<StructuralItemExportFileVm> Handle(GetStructuralItemsExportQuery request, CancellationToken cancellationToken)
        {
            var allStructuralItems = _mapper.Map<List<CommandStructuralItem>>((await _UnitOfWork.RepositoryStructuralItem.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allStructuralItems);

            var eventExportFileDto = new StructuralItemExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
