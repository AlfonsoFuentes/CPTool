using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.ElectricalBoxs.Queries.Export
{
    public class ExportElectricalBoxsQueryHandler : IRequestHandler<ExportElectricalBoxsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportElectricalBoxsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportElectricalBoxsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "ElectricalBox";
            result.ExportFileName += $".{request.Type}";
            var allElectricalBox = (await _UnitOfWork.RepositoryElectricalBox.GetAllAsync());
            var allElectricalBoxDTO = _mapper.Map<List<CommandElectricalBox>>(allElectricalBox);
            if (request.Filter != null)
            {
                allElectricalBoxDTO = allElectricalBoxDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allElectricalBoxDTO = allElectricalBoxDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allElectricalBoxDTO, request.Dictionary, "ElectricalBox");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allElectricalBoxDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allElectricalBoxDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
