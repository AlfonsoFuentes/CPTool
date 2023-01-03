using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PaintingItems.Queries.Export
{
    public class ExportPaintingItemsQueryHandler : IRequestHandler<ExportPaintingItemsQuery, ExportBaseResponse>
    {
       
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportPaintingItemsQueryHandler( ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
           
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportPaintingItemsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "PaintingItem";
             result.ExportFileName += $"_{DateTime.Now.ToString()}.{request.Type}";
           

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(request.List, request.Dictionary, "PaintingItem");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(request.List);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(request.List, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
