using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypes.Queries.Export
{
    public class ExportEquipmentTypesQueryHandler : IRequestHandler<ExportEquipmentTypesQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportEquipmentTypesQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportEquipmentTypesQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "EquipmentType";
            result.ExportFileName += $".{request.Type}";
            var allEquipmentType = (await _UnitOfWork.RepositoryEquipmentType.GetAllAsync());
            var allEquipmentTypeDTO = _mapper.Map<List<CommandEquipmentType>>(allEquipmentType);
            if (request.Filter != null)
            {
                allEquipmentTypeDTO = allEquipmentTypeDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allEquipmentTypeDTO = allEquipmentTypeDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allEquipmentTypeDTO, request.Dictionary, "EquipmentType");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allEquipmentTypeDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allEquipmentTypeDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
