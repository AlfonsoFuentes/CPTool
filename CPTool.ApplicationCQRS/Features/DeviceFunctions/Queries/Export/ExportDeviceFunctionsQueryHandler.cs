using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.DeviceFunctions.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctions.Queries.Export
{
    public class ExportDeviceFunctionsQueryHandler : IRequestHandler<ExportDeviceFunctionsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportDeviceFunctionsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportDeviceFunctionsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "DeviceFunction";
            result.ExportFileName += $".{request.Type}";
            var allDeviceFunction = (await _UnitOfWork.RepositoryDeviceFunction.GetAllAsync());
            var allDeviceFunctionDTO = _mapper.Map<List<CommandDeviceFunction>>(allDeviceFunction);
            if (request.Filter != null)
            {
                allDeviceFunctionDTO = allDeviceFunctionDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allDeviceFunctionDTO = allDeviceFunctionDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allDeviceFunctionDTO, request.Dictionary, "DeviceFunction");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allDeviceFunctionDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allDeviceFunctionDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
