using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.PropertyPackages.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PropertyPackages.Queries.ExportExcel
{
    public class ExportPropertyPackageQuery : IRequest<byte[]>
    {
        public Func<CommandPropertyPackage, bool>? Filter { get; set; }
        public Func<CommandPropertyPackage, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportPropertyPackageQueryHandler :
         IRequestHandler<ExportPropertyPackageQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandPropertyPackage _dto = new();
        public ExportPropertyPackageQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportPropertyPackageQuery request, CancellationToken cancellationToken)
        {


            var allPropertyPackage = (await _UnitOfWork.RepositoryPropertyPackage.GetAllAsync());
            var allPropertyPackageDTO= _mapper.Map<List<CommandPropertyPackage>>(allPropertyPackage);
            if (request.Filter != null)
            {
                allPropertyPackageDTO = allPropertyPackageDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allPropertyPackageDTO = allPropertyPackageDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allPropertyPackageDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandPropertyPackage, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "PropertyPackage");
            return result;
        }
    }
}
