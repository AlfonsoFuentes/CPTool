using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.InstrumentItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.InstrumentItems.Queries.Export
{
    public class ExportInstrumentItemsQueryHandler : IRequestHandler<ExportInstrumentItemsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportInstrumentItemsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportInstrumentItemsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "InstrumentItem";
            result.ExportFileName += $".{request.Type}";
            var allInstrumentItem = (await _UnitOfWork.RepositoryInstrumentItem.GetAllAsync());
            var allInstrumentItemDTO = _mapper.Map<List<CommandInstrumentItem>>(allInstrumentItem);
            if (request.Filter != null)
            {
                allInstrumentItemDTO = allInstrumentItemDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allInstrumentItemDTO = allInstrumentItemDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allInstrumentItemDTO, request.Dictionary, "InstrumentItem");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allInstrumentItemDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allInstrumentItemDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
