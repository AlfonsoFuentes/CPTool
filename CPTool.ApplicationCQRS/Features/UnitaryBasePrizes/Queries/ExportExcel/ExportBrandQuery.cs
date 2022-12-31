using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Queries.ExportExcel
{
    public class ExportUnitaryBasePrizeQuery : IRequest<byte[]>
    {
        public Func<CommandUnitaryBasePrize, bool>? Filter { get; set; }
        public Func<CommandUnitaryBasePrize, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportUnitaryBasePrizeQueryHandler :
         IRequestHandler<ExportUnitaryBasePrizeQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandUnitaryBasePrize _dto = new();
        public ExportUnitaryBasePrizeQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportUnitaryBasePrizeQuery request, CancellationToken cancellationToken)
        {


            var allUnitaryBasePrize = (await _UnitOfWork.RepositoryUnitaryBasePrize.GetAllAsync());
            var allUnitaryBasePrizeDTO= _mapper.Map<List<CommandUnitaryBasePrize>>(allUnitaryBasePrize);
            if (request.Filter != null)
            {
                allUnitaryBasePrizeDTO = allUnitaryBasePrizeDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allUnitaryBasePrizeDTO = allUnitaryBasePrizeDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allUnitaryBasePrizeDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandUnitaryBasePrize, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "UnitaryBasePrize");
            return result;
        }
    }
}
