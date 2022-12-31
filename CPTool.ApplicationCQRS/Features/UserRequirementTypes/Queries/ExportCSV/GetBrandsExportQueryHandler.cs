using AutoMapper;
using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.UserRequirementTypes.Queries.ExportCSV
{
    public class GetUserRequirementTypesExportQueryHandler : IRequestHandler<GetUserRequirementTypesExportQuery, UserRequirementTypeExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetUserRequirementTypesExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<UserRequirementTypeExportFileVm> Handle(GetUserRequirementTypesExportQuery request, CancellationToken cancellationToken)
        {
            var allUserRequirementTypes = _mapper.Map<List<CommandUserRequirementType>>((await _UnitOfWork.RepositoryUserRequirementType.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allUserRequirementTypes);

            var eventExportFileDto = new UserRequirementTypeExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
