using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Queries.Export
{
    public class ExportEquipmentTypeSubsQueryHandler : IRequestHandler<ExportEquipmentTypeSubsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportEquipmentTypeSubsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportEquipmentTypeSubsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "EquipmentTypeSub";
            result.ExportFileName += $".{request.Type}";
            var allEquipmentTypeSub = (await _UnitOfWork.RepositoryEquipmentTypeSub.GetAllAsync());
            var allEquipmentTypeSubDTO = _mapper.Map<List<CommandEquipmentTypeSub>>(allEquipmentTypeSub);
            if (request.Filter != null)
            {
                allEquipmentTypeSubDTO = allEquipmentTypeSubDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allEquipmentTypeSubDTO = allEquipmentTypeSubDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allEquipmentTypeSubDTO, request.Dictionary, "EquipmentTypeSub");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allEquipmentTypeSubDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allEquipmentTypeSubDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
