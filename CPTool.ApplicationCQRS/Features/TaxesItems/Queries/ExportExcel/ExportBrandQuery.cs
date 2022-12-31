using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.TaxesItems.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.TaxesItems.Queries.ExportExcel
{
    public class ExportTaxesItemQuery : IRequest<byte[]>
    {
        public Func<CommandTaxesItem, bool>? Filter { get; set; }
        public Func<CommandTaxesItem, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportTaxesItemQueryHandler :
         IRequestHandler<ExportTaxesItemQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandTaxesItem _dto = new();
        public ExportTaxesItemQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportTaxesItemQuery request, CancellationToken cancellationToken)
        {


            var allTaxesItem = (await _UnitOfWork.RepositoryTaxesItem.GetAllAsync());
            var allTaxesItemDTO= _mapper.Map<List<CommandTaxesItem>>(allTaxesItem);
            if (request.Filter != null)
            {
                allTaxesItemDTO = allTaxesItemDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allTaxesItemDTO = allTaxesItemDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allTaxesItemDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandTaxesItem, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "TaxesItem");
            return result;
        }
    }
}
