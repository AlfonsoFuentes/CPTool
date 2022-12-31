using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.SignalModifiers.Queries.Export
{
    public class ExportSignalModifiersQueryHandler : IRequestHandler<ExportSignalModifiersQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportSignalModifiersQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportSignalModifiersQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "SignalModifier";
            result.ExportFileName += $".{request.Type}";
            var allSignalModifier = (await _UnitOfWork.RepositorySignalModifier.GetAllAsync());
            var allSignalModifierDTO = _mapper.Map<List<CommandSignalModifier>>(allSignalModifier);
            if (request.Filter != null)
            {
                allSignalModifierDTO = allSignalModifierDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allSignalModifierDTO = allSignalModifierDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allSignalModifierDTO, request.Dictionary, "SignalModifier");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allSignalModifierDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allSignalModifierDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
