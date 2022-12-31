using AutoMapper;
using CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.SignalModifiers.Queries.ExportCSV
{
    public class GetSignalModifiersExportQueryHandler : IRequestHandler<GetSignalModifiersExportQuery, SignalModifierExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetSignalModifiersExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<SignalModifierExportFileVm> Handle(GetSignalModifiersExportQuery request, CancellationToken cancellationToken)
        {
            var allSignalModifiers = _mapper.Map<List<CommandSignalModifier>>((await _UnitOfWork.RepositorySignalModifier.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allSignalModifiers);

            var eventExportFileDto = new SignalModifierExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
