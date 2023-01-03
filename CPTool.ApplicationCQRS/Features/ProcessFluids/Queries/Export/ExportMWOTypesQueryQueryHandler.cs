using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.ProcessFluids.Queries.Export
{
    public class ExportProcessFluidsQueryHandler : IRequestHandler<ExportProcessFluidsQuery, ExportBaseResponse>
    {
       
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportProcessFluidsQueryHandler( ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
          
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportProcessFluidsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "ProcessFluid";
             result.ExportFileName += $"_{DateTime.Now.ToString()}.{request.Type}";
           
            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(request.List, request.Dictionary, "ProcessFluid");
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
