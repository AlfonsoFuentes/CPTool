using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.ContingencyItems.Queries.Export
{
    public class ExportContingencyItemsQueryHandler : IRequestHandler<ExportContingencyItemsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportContingencyItemsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportContingencyItemsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "ContingencyItem";
            result.ExportFileName += $".{request.Type}";
            var allContingencyItem = (await _UnitOfWork.RepositoryContingencyItem.GetAllAsync());
            var allContingencyItemDTO = _mapper.Map<List<CommandContingencyItem>>(allContingencyItem);
            if (request.Filter != null)
            {
                allContingencyItemDTO = allContingencyItemDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allContingencyItemDTO = allContingencyItemDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allContingencyItemDTO, request.Dictionary, "ContingencyItem");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allContingencyItemDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allContingencyItemDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
