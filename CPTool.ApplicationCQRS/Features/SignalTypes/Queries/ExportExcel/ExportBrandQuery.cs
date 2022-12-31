using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.SignalTypes.Queries.ExportExcel
{
    public class ExportSignalTypeQuery : IRequest<byte[]>
    {
        public Func<CommandSignalType, bool>? Filter { get; set; }
        public Func<CommandSignalType, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportSignalTypeQueryHandler :
         IRequestHandler<ExportSignalTypeQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandSignalType _dto = new();
        public ExportSignalTypeQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportSignalTypeQuery request, CancellationToken cancellationToken)
        {


            var allSignalType = (await _UnitOfWork.RepositorySignalType.GetAllAsync());
            var allSignalTypeDTO= _mapper.Map<List<CommandSignalType>>(allSignalType);
            if (request.Filter != null)
            {
                allSignalTypeDTO = allSignalTypeDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allSignalTypeDTO = allSignalTypeDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allSignalTypeDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandSignalType, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "SignalType");
            return result;
        }
    }
}
