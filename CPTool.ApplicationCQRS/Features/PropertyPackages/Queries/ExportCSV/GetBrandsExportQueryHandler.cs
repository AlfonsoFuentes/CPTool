using AutoMapper;
using CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PropertyPackages.Queries.ExportCSV
{
    public class GetPropertyPackagesExportQueryHandler : IRequestHandler<GetPropertyPackagesExportQuery, PropertyPackageExportFileVm>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetPropertyPackagesExportQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
        }

        public async Task<PropertyPackageExportFileVm> Handle(GetPropertyPackagesExportQuery request, CancellationToken cancellationToken)
        {
            var allPropertyPackages = _mapper.Map<List<CommandPropertyPackage>>((await _UnitOfWork.RepositoryPropertyPackage.GetAllAsync()));

            var fileData = _csvExporter.ExportToCsv(allPropertyPackages);

            var eventExportFileDto = new PropertyPackageExportFileVm() { ContentType = "text/csv", Data = fileData, ExportFileName = $"{Guid.NewGuid()}.csv" };

            return eventExportFileDto;
        }
    }
}
