using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.DeviceFunctionModifiers.Queries.Export
{
    public class ExportDeviceFunctionModifiersQueryHandler : IRequestHandler<ExportDeviceFunctionModifiersQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportDeviceFunctionModifiersQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportDeviceFunctionModifiersQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "DeviceFunctionModifier";
            result.ExportFileName += $".{request.Type}";
            var allDeviceFunctionModifier = (await _UnitOfWork.RepositoryDeviceFunctionModifier.GetAllAsync());
            var allDeviceFunctionModifierDTO = _mapper.Map<List<CommandDeviceFunctionModifier>>(allDeviceFunctionModifier);
            if (request.Filter != null)
            {
                allDeviceFunctionModifierDTO = allDeviceFunctionModifierDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allDeviceFunctionModifierDTO = allDeviceFunctionModifierDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allDeviceFunctionModifierDTO, request.Dictionary, "DeviceFunctionModifier");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allDeviceFunctionModifierDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allDeviceFunctionModifierDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
