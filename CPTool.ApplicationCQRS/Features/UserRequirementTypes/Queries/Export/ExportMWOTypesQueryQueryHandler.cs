using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.UserRequirementTypes.Queries.Export
{
    public class ExportUserRequirementTypesQueryHandler : IRequestHandler<ExportUserRequirementTypesQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportUserRequirementTypesQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportUserRequirementTypesQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "UserRequirementType";
            result.ExportFileName += $".{request.Type}";
            var allUserRequirementType = (await _UnitOfWork.RepositoryUserRequirementType.GetAllAsync());
            var allUserRequirementTypeDTO = _mapper.Map<List<CommandUserRequirementType>>(allUserRequirementType);
            if (request.Filter != null)
            {
                allUserRequirementTypeDTO = allUserRequirementTypeDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allUserRequirementTypeDTO = allUserRequirementTypeDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allUserRequirementTypeDTO, request.Dictionary, "UserRequirementType");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allUserRequirementTypeDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allUserRequirementTypeDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
