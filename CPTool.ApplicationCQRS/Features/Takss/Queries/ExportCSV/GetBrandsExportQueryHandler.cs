using AutoMapper;
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Takss.Queries.ExportCSV
{
    public class GetTakssExportQueryHandler : IRequestHandler<GetTakssExportQuery, TaksExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetTakssExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<TaksExportFileVm> Handle(GetTakssExportQuery request, CancellationToken cancellationToken)
        {
            var allTakss = _mapper.Map<List<CommandTaks>>((await _UnitOfWork.RepositoryTaks.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allTakss);

            var eventExportFileDto = new TaksExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
