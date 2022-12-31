using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.EquipmentItems.Queries.Export
{
    public class ExportEquipmentItemsQueryHandler : IRequestHandler<ExportEquipmentItemsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportEquipmentItemsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportEquipmentItemsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "EquipmentItem";
            result.ExportFileName += $".{request.Type}";
            var allEquipmentItem = (await _UnitOfWork.RepositoryEquipmentItem.GetAllAsync());
            var allEquipmentItemDTO = _mapper.Map<List<CommandEquipmentItem>>(allEquipmentItem);
            if (request.Filter != null)
            {
                allEquipmentItemDTO = allEquipmentItemDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allEquipmentItemDTO = allEquipmentItemDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allEquipmentItemDTO, request.Dictionary, "EquipmentItem");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allEquipmentItemDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allEquipmentItemDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
