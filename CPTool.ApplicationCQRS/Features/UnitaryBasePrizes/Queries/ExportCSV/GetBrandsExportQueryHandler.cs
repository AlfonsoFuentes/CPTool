using AutoMapper;
using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Queries.ExportCSV
{
    public class GetUnitaryBasePrizesExportQueryHandler : IRequestHandler<GetUnitaryBasePrizesExportQuery, UnitaryBasePrizeExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetUnitaryBasePrizesExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<UnitaryBasePrizeExportFileVm> Handle(GetUnitaryBasePrizesExportQuery request, CancellationToken cancellationToken)
        {
            var allUnitaryBasePrizes = _mapper.Map<List<CommandUnitaryBasePrize>>((await _UnitOfWork.RepositoryUnitaryBasePrize.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allUnitaryBasePrizes);

            var eventExportFileDto = new UnitaryBasePrizeExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
