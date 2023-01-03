using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.StructuralItems.Queries.Export
{
    public class ExportStructuralItemsQueryHandler : IRequestHandler<ExportStructuralItemsQuery, ExportBaseResponse>
    {
       
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportStructuralItemsQueryHandler( ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
           
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportStructuralItemsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "StructuralItem";
             result.ExportFileName += $"_{DateTime.Now.ToString()}.{request.Type}";
           

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(request.List, request.Dictionary, "StructuralItem");
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
