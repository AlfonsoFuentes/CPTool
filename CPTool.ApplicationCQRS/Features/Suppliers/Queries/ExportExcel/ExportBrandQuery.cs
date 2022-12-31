using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Suppliers.Queries.ExportExcel
{
    public class ExportSupplierQuery : IRequest<byte[]>
    {
        public Func<CommandSupplier, bool>? Filter { get; set; }
        public Func<CommandSupplier, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportSupplierQueryHandler :
         IRequestHandler<ExportSupplierQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandSupplier _dto = new();
        public ExportSupplierQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportSupplierQuery request, CancellationToken cancellationToken)
        {


            var allSupplier = (await _UnitOfWork.RepositorySupplier.GetAllAsync());
            var allSupplierDTO= _mapper.Map<List<CommandSupplier>>(allSupplier);
            if (request.Filter != null)
            {
                allSupplierDTO = allSupplierDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allSupplierDTO = allSupplierDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allSupplierDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandSupplier, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "Supplier");
            return result;
        }
    }
}
