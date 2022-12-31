using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.ProcessConditions.Queries.ExportExcel
{
    public class ExportProcessConditionQuery : IRequest<byte[]>
    {
        public Func<CommandProcessCondition, bool>? Filter { get; set; }
        public Func<CommandProcessCondition, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportProcessConditionQueryHandler :
         IRequestHandler<ExportProcessConditionQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandProcessCondition _dto = new();
        public ExportProcessConditionQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportProcessConditionQuery request, CancellationToken cancellationToken)
        {


            var allProcessCondition = (await _UnitOfWork.RepositoryProcessCondition.GetAllAsync());
            var allProcessConditionDTO= _mapper.Map<List<CommandProcessCondition>>(allProcessCondition);
            if (request.Filter != null)
            {
                allProcessConditionDTO = allProcessConditionDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allProcessConditionDTO = allProcessConditionDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allProcessConditionDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandProcessCondition, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "ProcessCondition");
            return result;
        }
    }
}
