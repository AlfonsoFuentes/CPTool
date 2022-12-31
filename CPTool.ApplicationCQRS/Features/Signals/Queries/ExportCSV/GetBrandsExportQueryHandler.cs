using AutoMapper;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Signals.Queries.ExportCSV
{
    public class GetSignalsExportQueryHandler : IRequestHandler<GetSignalsExportQuery, SignalExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetSignalsExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<SignalExportFileVm> Handle(GetSignalsExportQuery request, CancellationToken cancellationToken)
        {
            var allSignals = _mapper.Map<List<CommandSignal>>((await _UnitOfWork.RepositorySignal.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allSignals);

            var eventExportFileDto = new SignalExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
