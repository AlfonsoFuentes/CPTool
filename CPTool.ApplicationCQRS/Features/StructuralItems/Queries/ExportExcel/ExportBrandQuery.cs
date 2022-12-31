using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.StructuralItems.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.StructuralItems.Queries.ExportExcel
{
    public class ExportStructuralItemQuery : IRequest<byte[]>
    {
        public Func<CommandStructuralItem, bool>? Filter { get; set; }
        public Func<CommandStructuralItem, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportStructuralItemQueryHandler :
         IRequestHandler<ExportStructuralItemQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandStructuralItem _dto = new();
        public ExportStructuralItemQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportStructuralItemQuery request, CancellationToken cancellationToken)
        {


            var allStructuralItem = (await _UnitOfWork.RepositoryStructuralItem.GetAllAsync());
            var allStructuralItemDTO= _mapper.Map<List<CommandStructuralItem>>(allStructuralItem);
            if (request.Filter != null)
            {
                allStructuralItemDTO = allStructuralItemDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allStructuralItemDTO = allStructuralItemDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allStructuralItemDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandStructuralItem, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "StructuralItem");
            return result;
        }
    }
}
