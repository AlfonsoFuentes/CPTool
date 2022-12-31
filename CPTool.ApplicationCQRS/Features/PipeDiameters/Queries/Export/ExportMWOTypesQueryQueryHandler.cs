using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Queries.Export
{
    public class ExportPipeDiametersQueryHandler : IRequestHandler<ExportPipeDiametersQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportPipeDiametersQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportPipeDiametersQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "PipeDiameter";
            result.ExportFileName += $".{request.Type}";
            var allPipeDiameter = (await _UnitOfWork.RepositoryPipeDiameter.GetAllAsync());
            var allPipeDiameterDTO = _mapper.Map<List<CommandPipeDiameter>>(allPipeDiameter);
            if (request.Filter != null)
            {
                allPipeDiameterDTO = allPipeDiameterDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allPipeDiameterDTO = allPipeDiameterDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allPipeDiameterDTO, request.Dictionary, "PipeDiameter");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allPipeDiameterDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allPipeDiameterDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
