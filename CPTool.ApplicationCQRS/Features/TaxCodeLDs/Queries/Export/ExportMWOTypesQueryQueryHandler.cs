using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLDs.Queries.Export
{
    public class ExportTaxCodeLDsQueryHandler : IRequestHandler<ExportTaxCodeLDsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportTaxCodeLDsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportTaxCodeLDsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "TaxCodeLD";
            result.ExportFileName += $".{request.Type}";
            var allTaxCodeLD = (await _UnitOfWork.RepositoryTaxCodeLD.GetAllAsync());
            var allTaxCodeLDDTO = _mapper.Map<List<CommandTaxCodeLD>>(allTaxCodeLD);
            if (request.Filter != null)
            {
                allTaxCodeLDDTO = allTaxCodeLDDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allTaxCodeLDDTO = allTaxCodeLDDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allTaxCodeLDDTO, request.Dictionary, "TaxCodeLD");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allTaxCodeLDDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allTaxCodeLDDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
