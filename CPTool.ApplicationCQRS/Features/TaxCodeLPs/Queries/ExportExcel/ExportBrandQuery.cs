using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.TaxCodeLPs.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLPs.Queries.ExportExcel
{
    public class ExportTaxCodeLPQuery : IRequest<byte[]>
    {
        public Func<CommandTaxCodeLP, bool>? Filter { get; set; }
        public Func<CommandTaxCodeLP, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportTaxCodeLPQueryHandler :
         IRequestHandler<ExportTaxCodeLPQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandTaxCodeLP _dto = new();
        public ExportTaxCodeLPQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportTaxCodeLPQuery request, CancellationToken cancellationToken)
        {


            var allTaxCodeLP = (await _UnitOfWork.RepositoryTaxCodeLP.GetAllAsync());
            var allTaxCodeLPDTO= _mapper.Map<List<CommandTaxCodeLP>>(allTaxCodeLP);
            if (request.Filter != null)
            {
                allTaxCodeLPDTO = allTaxCodeLPDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allTaxCodeLPDTO = allTaxCodeLPDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allTaxCodeLPDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandTaxCodeLP, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "TaxCodeLP");
            return result;
        }
    }
}
