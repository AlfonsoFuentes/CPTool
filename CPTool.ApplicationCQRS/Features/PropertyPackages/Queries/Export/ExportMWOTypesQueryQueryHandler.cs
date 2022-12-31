﻿using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Responses;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PropertyPackages.Queries.Export
{
    public class ExportPropertyPackagesQueryHandler : IRequestHandler<ExportPropertyPackagesQuery, ExportBaseResponse>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;
        private readonly IExcelService _excelService;
        private readonly IPDFService _pdfService;
        public ExportPropertyPackagesQueryHandler(IMapper mapper, IUnitOfWork UnitOfWork, ICsvExporter csvExporter, IExcelService excelService, IPDFService pdfService)
        {
            _mapper = mapper;
            _UnitOfWork = UnitOfWork;
            _csvExporter = csvExporter;
            _excelService = excelService;
            _pdfService=pdfService; 
        }

        public async Task<ExportBaseResponse> Handle(ExportPropertyPackagesQuery request, CancellationToken cancellationToken)
        {
            ExportBaseResponse result = new();
            result.ExportFileName = "PropertyPackage";
            result.ExportFileName += $".{request.Type}";
            var allPropertyPackage = (await _UnitOfWork.RepositoryPropertyPackage.GetAllAsync());
            var allPropertyPackageDTO = _mapper.Map<List<CommandPropertyPackage>>(allPropertyPackage);
            if (request.Filter != null)
            {
                allPropertyPackageDTO = allPropertyPackageDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allPropertyPackageDTO = allPropertyPackageDTO!.OrderBy(request.OrderBy).ToList();
            }

            if (request.Type == "xlsx")
            {
                result.Data = await _excelService.ExportAsync(allPropertyPackageDTO, request.Dictionary, "PropertyPackage");
                result.ContentType = ExportBaseResponse.ExcelContentType;

            }
            else if (request.Type == "csv")
            {
                result.Data = _csvExporter.ExportToCsv(allPropertyPackageDTO);
                result.ContentType = ExportBaseResponse.CSVContentType;

            }
            else if (request.Type == "pdf")
            {
                result.Data=await _pdfService.ExportToPDF(allPropertyPackageDTO, request.Dictionary);
                result.ContentType = ExportBaseResponse.pdfContentType;
            }
            return result;
        }
    }
}
