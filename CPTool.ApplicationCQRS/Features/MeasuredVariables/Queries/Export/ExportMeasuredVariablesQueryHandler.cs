using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.MeasuredVariables.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.MeasuredVariables.Queries.Export
{
    public class ExportMeasuredVariablesQueryHandler : IRequestHandler<ExportMeasuredVariablesQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportMeasuredVariablesQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportMeasuredVariablesQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "MeasuredVariable";
            result.ExportFileName += $".{request.Type}";
            var allMeasuredVariable = (await _UnitOfWork.RepositoryMeasuredVariable.GetAllAsync());
            var allMeasuredVariableDTO = _mapper.Map<List<CommandMeasuredVariable>>(allMeasuredVariable);
            if (request.Filter != null)
            {
                allMeasuredVariableDTO = allMeasuredVariableDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allMeasuredVariableDTO = allMeasuredVariableDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allMeasuredVariableDTO, request.Dictionary, "MeasuredVariable");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allMeasuredVariableDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allMeasuredVariableDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
