using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.TestingItems.Queries.ExportExcel
{
    public class ExportTestingItemQuery : IRequest<byte[]>
    {
        public Func<CommandTestingItem, bool>? Filter { get; set; }
        public Func<CommandTestingItem, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportTestingItemQueryHandler :
         IRequestHandler<ExportTestingItemQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandTestingItem _dto = new();
        public ExportTestingItemQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportTestingItemQuery request, CancellationToken cancellationToken)
        {


            var allTestingItem = (await _UnitOfWork.RepositoryTestingItem.GetAllAsync());
            var allTestingItemDTO= _mapper.Map<List<CommandTestingItem>>(allTestingItem);
            if (request.Filter != null)
            {
                allTestingItemDTO = allTestingItemDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allTestingItemDTO = allTestingItemDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allTestingItemDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandTestingItem, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "TestingItem");
            return result;
        }
    }
}
