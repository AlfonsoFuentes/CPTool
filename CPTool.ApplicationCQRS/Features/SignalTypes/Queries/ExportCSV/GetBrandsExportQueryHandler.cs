using AutoMapper;
using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.SignalTypes.Queries.ExportCSV
{
    public class GetSignalTypesExportQueryHandler : IRequestHandler<GetSignalTypesExportQuery, SignalTypeExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetSignalTypesExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<SignalTypeExportFileVm> Handle(GetSignalTypesExportQuery request, CancellationToken cancellationToken)
        {
            var allSignalTypes = _mapper.Map<List<CommandSignalType>>((await _UnitOfWork.RepositorySignalType.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allSignalTypes);

            var eventExportFileDto = new SignalTypeExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
