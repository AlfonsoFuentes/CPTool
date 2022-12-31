using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Queries.Export
{
    public class ExportProcessConditionsQueryHandler : IRequestHandler<ExportProcessConditionsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportProcessConditionsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportProcessConditionsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "ProcessCondition";
            result.ExportFileName += $".{request.Type}";
            var allProcessCondition = (await _UnitOfWork.RepositoryProcessCondition.GetAllAsync());
            var allProcessConditionDTO = _mapper.Map<List<CommandProcessCondition>>(allProcessCondition);
            if (request.Filter != null)
            {
                allProcessConditionDTO = allProcessConditionDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allProcessConditionDTO = allProcessConditionDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allProcessConditionDTO, request.Dictionary, "ProcessCondition");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allProcessConditionDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allProcessConditionDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
