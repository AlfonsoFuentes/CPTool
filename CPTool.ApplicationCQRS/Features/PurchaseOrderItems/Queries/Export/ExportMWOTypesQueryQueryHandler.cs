using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Queries.Export
{
    public class ExportPurchaseOrderItemsQueryHandler : IRequestHandler<ExportPurchaseOrderItemsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportPurchaseOrderItemsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportPurchaseOrderItemsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "PurchaseOrderItem";
            result.ExportFileName += $".{request.Type}";
            var allPurchaseOrderItem = (await _UnitOfWork.RepositoryPurchaseOrderItem.GetAllAsync());
            var allPurchaseOrderItemDTO = _mapper.Map<List<CommandPurchaseOrderItem>>(allPurchaseOrderItem);
            if (request.Filter != null)
            {
                allPurchaseOrderItemDTO = allPurchaseOrderItemDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allPurchaseOrderItemDTO = allPurchaseOrderItemDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allPurchaseOrderItemDTO, request.Dictionary, "PurchaseOrderItem");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allPurchaseOrderItemDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allPurchaseOrderItemDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
