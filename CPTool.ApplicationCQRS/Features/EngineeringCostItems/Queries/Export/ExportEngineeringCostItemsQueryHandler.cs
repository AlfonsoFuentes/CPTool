using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.EngineeringCostItems.Queries.Export
{
    public class ExportEngineeringCostItemsQueryHandler : IRequestHandler<ExportEngineeringCostItemsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportEngineeringCostItemsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportEngineeringCostItemsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "EngineeringCostItem";
            result.ExportFileName += $".{request.Type}";
            var allEngineeringCostItem = (await _UnitOfWork.RepositoryEngineeringCostItem.GetAllAsync());
            var allEngineeringCostItemDTO = _mapper.Map<List<CommandEngineeringCostItem>>(allEngineeringCostItem);
            if (request.Filter != null)
            {
                allEngineeringCostItemDTO = allEngineeringCostItemDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allEngineeringCostItemDTO = allEngineeringCostItemDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allEngineeringCostItemDTO, request.Dictionary, "EngineeringCostItem");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allEngineeringCostItemDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allEngineeringCostItemDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
