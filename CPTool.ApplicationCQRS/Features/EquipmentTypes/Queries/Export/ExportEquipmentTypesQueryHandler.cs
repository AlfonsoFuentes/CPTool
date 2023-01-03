using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypes.Queries.Export
{
    public class ExportEquipmentTypesQueryHandler : IRequestHandler<ExportEquipmentTypesQuery, ExportBaseResponse>
    {
      
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportEquipmentTypesQueryHandler( ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
          
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportEquipmentTypesQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "EquipmentType";
             result.ExportFileName += $"_{DateTime.Now.ToString()}.{request.Type}";
           
            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(request.List, request.Dictionary, "EquipmentType");
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
