using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PipingItems.Queries.ExportExcel
{
    public class ExportPipingItemQuery : IRequest<byte[]>
    {
        public Func<CommandPipingItem, bool>? Filter { get; set; }
        public Func<CommandPipingItem, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportPipingItemQueryHandler :
         IRequestHandler<ExportPipingItemQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandPipingItem _dto = new();
        public ExportPipingItemQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportPipingItemQuery request, CancellationToken cancellationToken)
        {


            var allPipingItem = (await _UnitOfWork.RepositoryPipingItem.GetAllAsync());
            var allPipingItemDTO= _mapper.Map<List<CommandPipingItem>>(allPipingItem);
            if (request.Filter != null)
            {
                allPipingItemDTO = allPipingItemDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allPipingItemDTO = allPipingItemDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allPipingItemDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandPipingItem, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "PipingItem");
            return result;
        }
    }
}
