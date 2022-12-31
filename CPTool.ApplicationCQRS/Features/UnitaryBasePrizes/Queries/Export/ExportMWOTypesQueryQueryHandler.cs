using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Queries.Export
{
    public class ExportUnitaryBasePrizesQueryHandler : IRequestHandler<ExportUnitaryBasePrizesQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportUnitaryBasePrizesQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportUnitaryBasePrizesQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "UnitaryBasePrize";
            result.ExportFileName += $".{request.Type}";
            var allUnitaryBasePrize = (await _UnitOfWork.RepositoryUnitaryBasePrize.GetAllAsync());
            var allUnitaryBasePrizeDTO = _mapper.Map<List<CommandUnitaryBasePrize>>(allUnitaryBasePrize);
            if (request.Filter != null)
            {
                allUnitaryBasePrizeDTO = allUnitaryBasePrizeDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allUnitaryBasePrizeDTO = allUnitaryBasePrizeDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allUnitaryBasePrizeDTO, request.Dictionary, "UnitaryBasePrize");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allUnitaryBasePrizeDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allUnitaryBasePrizeDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
