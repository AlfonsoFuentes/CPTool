using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrders.Queries.Export
{
    public class ExportPurchaseOrdersQueryHandler : IRequestHandler<ExportPurchaseOrdersQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportPurchaseOrdersQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportPurchaseOrdersQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "PurchaseOrder";
            result.ExportFileName += $".{request.Type}";
            var allPurchaseOrder = (await _UnitOfWork.RepositoryPurchaseOrder.GetAllAsync());
            var allPurchaseOrderDTO = _mapper.Map<List<CommandPurchaseOrder>>(allPurchaseOrder);
            if (request.Filter != null)
            {
                allPurchaseOrderDTO = allPurchaseOrderDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allPurchaseOrderDTO = allPurchaseOrderDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allPurchaseOrderDTO, request.Dictionary, "PurchaseOrder");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allPurchaseOrderDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allPurchaseOrderDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
