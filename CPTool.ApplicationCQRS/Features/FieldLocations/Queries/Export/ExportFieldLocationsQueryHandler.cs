using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.FieldLocations.Queries.Export
{
    public class ExportFieldLocationsQueryHandler : IRequestHandler<ExportFieldLocationsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportFieldLocationsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportFieldLocationsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "FieldLocation";
            result.ExportFileName += $".{request.Type}";
            var allFieldLocation = (await _UnitOfWork.RepositoryFieldLocation.GetAllAsync());
            var allFieldLocationDTO = _mapper.Map<List<CommandFieldLocation>>(allFieldLocation);
            if (request.Filter != null)
            {
                allFieldLocationDTO = allFieldLocationDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allFieldLocationDTO = allFieldLocationDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allFieldLocationDTO, request.Dictionary, "FieldLocation");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allFieldLocationDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allFieldLocationDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
