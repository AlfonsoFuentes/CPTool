using AutoMapper;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Queries.ExportCSV
{
    public class GetPipeDiametersExportQueryHandler : IRequestHandler<GetPipeDiametersExportQuery, PipeDiameterExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetPipeDiametersExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<PipeDiameterExportFileVm> Handle(GetPipeDiametersExportQuery request, CancellationToken cancellationToken)
        {
            var allPipeDiameters = _mapper.Map<List<CommandPipeDiameter>>((await _UnitOfWork.RepositoryPipeDiameter.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allPipeDiameters);

            var eventExportFileDto = new PipeDiameterExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
