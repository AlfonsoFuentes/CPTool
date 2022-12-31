using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.BrandSuppliers.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.BrandSuppliers.Queries.Export
{
    public class ExportBrandSuppliersQueryHandler : IRequestHandler<ExportBrandSuppliersQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportBrandSuppliersQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportBrandSuppliersQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "BrandSupplier";
            result.ExportFileName += $".{request.Type}";
            var allBrandSupplier = (await _UnitOfWork.RepositoryBrandSupplier.GetAllAsync());
            var allBrandSupplierDTO = _mapper.Map<List<CommandBrandSupplier>>(allBrandSupplier);
            if (request.Filter != null)
            {
                allBrandSupplierDTO = allBrandSupplierDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allBrandSupplierDTO = allBrandSupplierDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allBrandSupplierDTO, request.Dictionary, "BrandSupplier");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allBrandSupplierDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allBrandSupplierDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
