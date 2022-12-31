using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.Signals.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Signals.Queries.ExportExcel
{
    public class ExportSignalQuery : IRequest<byte[]>
    {
        public Func<CommandSignal, bool>? Filter { get; set; }
        public Func<CommandSignal, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportSignalQueryHandler :
         IRequestHandler<ExportSignalQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandSignal _dto = new();
        public ExportSignalQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportSignalQuery request, CancellationToken cancellationToken)
        {


            var allSignal = (await _UnitOfWork.RepositorySignal.GetAllAsync());
            var allSignalDTO= _mapper.Map<List<CommandSignal>>(allSignal);
            if (request.Filter != null)
            {
                allSignalDTO = allSignalDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allSignalDTO = allSignalDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allSignalDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandSignal, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "Signal");
            return result;
        }
    }
}
