using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.ProcessFluids.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.ProcessFluids.Queries.Export
{
    public class ExportProcessFluidsQueryHandler : IRequestHandler<ExportProcessFluidsQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportProcessFluidsQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportProcessFluidsQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "ProcessFluid";
            result.ExportFileName += $".{request.Type}";
            var allProcessFluid = (await _UnitOfWork.RepositoryProcessFluid.GetAllAsync());
            var allProcessFluidDTO = _mapper.Map<List<CommandProcessFluid>>(allProcessFluid);
            if (request.Filter != null)
            {
                allProcessFluidDTO = allProcessFluidDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allProcessFluidDTO = allProcessFluidDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allProcessFluidDTO, request.Dictionary, "ProcessFluid");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allProcessFluidDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allProcessFluidDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
