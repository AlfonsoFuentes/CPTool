using AutoMapper;
using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.UserRequirements.Queries.ExportCSV
{
    public class GetUserRequirementsExportQueryHandler : IRequestHandler<GetUserRequirementsExportQuery, UserRequirementExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetUserRequirementsExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<UserRequirementExportFileVm> Handle(GetUserRequirementsExportQuery request, CancellationToken cancellationToken)
        {
            var allUserRequirements = _mapper.Map<List<CommandUserRequirement>>((await _UnitOfWork.RepositoryUserRequirement.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allUserRequirements);

            var eventExportFileDto = new UserRequirementExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
