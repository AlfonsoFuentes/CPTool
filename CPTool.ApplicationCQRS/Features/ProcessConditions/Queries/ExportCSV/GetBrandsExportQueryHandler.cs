using AutoMapper;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Queries.ExportCSV
{
    public class GetProcessConditionsExportQueryHandler : IRequestHandler<GetProcessConditionsExportQuery, ProcessConditionExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetProcessConditionsExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<ProcessConditionExportFileVm> Handle(GetProcessConditionsExportQuery request, CancellationToken cancellationToken)
        {
            var allProcessConditions = _mapper.Map<List<CommandProcessCondition>>((await _UnitOfWork.RepositoryProcessCondition.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allProcessConditions);

            var eventExportFileDto = new ProcessConditionExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
