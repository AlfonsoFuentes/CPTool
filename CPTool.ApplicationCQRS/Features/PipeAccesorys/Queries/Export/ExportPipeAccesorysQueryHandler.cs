using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PipeAccesorys.Queries.Export
{
    public class ExportPipeAccesorysQueryHandler : IRequestHandler<ExportPipeAccesorysQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportPipeAccesorysQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportPipeAccesorysQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "PipeAccesory";
            result.ExportFileName += $".{request.Type}";
            var allPipeAccesory = (await _UnitOfWork.RepositoryPipeAccesory.GetAllAsync());
            var allPipeAccesoryDTO = _mapper.Map<List<CommandPipeAccesory>>(allPipeAccesory);
            if (request.Filter != null)
            {
                allPipeAccesoryDTO = allPipeAccesoryDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allPipeAccesoryDTO = allPipeAccesoryDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allPipeAccesoryDTO, request.Dictionary, "PipeAccesory");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allPipeAccesoryDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allPipeAccesoryDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
