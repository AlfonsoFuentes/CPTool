using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.DownPayments.Queries.Export
{
    public class ExportDownPaymentsQueryHandler : IRequestHandler<ExportDownPaymentsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportDownPaymentsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportDownPaymentsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "DownPayment";
            result.ExportFileName += $".{request.Type}";
            var allDownPayment = (await _UnitOfWork.RepositoryDownPayment.GetAllAsync());
            var allDownPaymentDTO = _mapper.Map<List<CommandDownPayment>>(allDownPayment);
            if (request.Filter != null)
            {
                allDownPaymentDTO = allDownPaymentDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allDownPaymentDTO = allDownPaymentDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allDownPaymentDTO, request.Dictionary, "DownPayment");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allDownPaymentDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allDownPaymentDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
