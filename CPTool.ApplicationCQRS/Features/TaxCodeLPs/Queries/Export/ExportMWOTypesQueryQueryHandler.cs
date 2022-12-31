using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLPs.Queries.Export
{
    public class ExportTaxCodeLPsQueryHandler : IRequestHandler<ExportTaxCodeLPsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportTaxCodeLPsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportTaxCodeLPsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "TaxCodeLP";
            result.ExportFileName += $".{request.Type}";
            var allTaxCodeLP = (await _UnitOfWork.RepositoryTaxCodeLP.GetAllAsync());
            var allTaxCodeLPDTO = _mapper.Map<List<CommandTaxCodeLP>>(allTaxCodeLP);
            if (request.Filter != null)
            {
                allTaxCodeLPDTO = allTaxCodeLPDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allTaxCodeLPDTO = allTaxCodeLPDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allTaxCodeLPDTO, request.Dictionary, "TaxCodeLP");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allTaxCodeLPDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allTaxCodeLPDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
