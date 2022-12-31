using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Takss.Queries.ExportExcel
{
    public class ExportTaksQuery : IRequest<byte[]>
    {
        public Func<CommandTaks, bool>? Filter { get; set; }
        public Func<CommandTaks, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportTaksQueryHandler :
         IRequestHandler<ExportTaksQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandTaks _dto = new();
        public ExportTaksQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportTaksQuery request, CancellationToken cancellationToken)
        {


            var allTaks = (await _UnitOfWork.RepositoryTaks.GetAllAsync());
            var allTaksDTO= _mapper.Map<List<CommandTaks>>(allTaks);
            if (request.Filter != null)
            {
                allTaksDTO = allTaksDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allTaksDTO = allTaksDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allTaksDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandTaks, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "Taks");
            return result;
        }
    }
}
