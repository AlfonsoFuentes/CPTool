using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.TaxCodeLDs.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.TaxCodeLDs.Queries.ExportExcel
{
    public class ExportTaxCodeLDQuery : IRequest<byte[]>
    {
        public Func<CommandTaxCodeLD, bool>? Filter { get; set; }
        public Func<CommandTaxCodeLD, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportTaxCodeLDQueryHandler :
         IRequestHandler<ExportTaxCodeLDQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandTaxCodeLD _dto = new();
        public ExportTaxCodeLDQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportTaxCodeLDQuery request, CancellationToken cancellationToken)
        {


            var allTaxCodeLD = (await _UnitOfWork.RepositoryTaxCodeLD.GetAllAsync());
            var allTaxCodeLDDTO= _mapper.Map<List<CommandTaxCodeLD>>(allTaxCodeLD);
            if (request.Filter != null)
            {
                allTaxCodeLDDTO = allTaxCodeLDDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allTaxCodeLDDTO = allTaxCodeLDDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allTaxCodeLDDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandTaxCodeLD, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "TaxCodeLD");
            return result;
        }
    }
}
