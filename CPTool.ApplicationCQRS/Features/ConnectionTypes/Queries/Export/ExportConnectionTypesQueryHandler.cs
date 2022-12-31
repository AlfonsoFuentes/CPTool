using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.ConnectionTypes.Queries.Export
{
    public class ExportConnectionTypesQueryHandler : IRequestHandler<ExportConnectionTypesQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportConnectionTypesQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportConnectionTypesQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "ConnectionType";
            result.ExportFileName += $".{request.Type}";
            var allConnectionType = (await _UnitOfWork.RepositoryConnectionType.GetAllAsync());
            var allConnectionTypeDTO = _mapper.Map<List<CommandConnectionType>>(allConnectionType);
            if (request.Filter != null)
            {
                allConnectionTypeDTO = allConnectionTypeDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allConnectionTypeDTO = allConnectionTypeDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allConnectionTypeDTO, request.Dictionary, "ConnectionType");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allConnectionTypeDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allConnectionTypeDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
