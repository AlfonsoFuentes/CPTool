using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.UserRequirements.Queries.Export
{
    public class ExportUserRequirementsQueryHandler : IRequestHandler<ExportUserRequirementsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportUserRequirementsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportUserRequirementsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "UserRequirement";
            result.ExportFileName += $".{request.Type}";
            var allUserRequirement = (await _UnitOfWork.RepositoryUserRequirement.GetAllAsync());
            var allUserRequirementDTO = _mapper.Map<List<CommandUserRequirement>>(allUserRequirement);
            if (request.Filter != null)
            {
                allUserRequirementDTO = allUserRequirementDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allUserRequirementDTO = allUserRequirementDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allUserRequirementDTO, request.Dictionary, "UserRequirement");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allUserRequirementDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allUserRequirementDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
