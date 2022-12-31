using AutoMapper;
using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Readouts.Queries.ExportCSV
{
    public class GetReadoutsExportQueryHandler : IRequestHandler<GetReadoutsExportQuery, ReadoutExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetReadoutsExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<ReadoutExportFileVm> Handle(GetReadoutsExportQuery request, CancellationToken cancellationToken)
        {
            var allReadouts = _mapper.Map<List<CommandReadout>>((await _UnitOfWork.RepositoryReadout.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allReadouts);

            var eventExportFileDto = new ReadoutExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
