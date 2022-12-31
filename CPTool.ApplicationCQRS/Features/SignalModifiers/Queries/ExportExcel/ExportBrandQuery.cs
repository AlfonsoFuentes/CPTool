using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.SignalModifiers.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.SignalModifiers.Queries.ExportExcel
{
    public class ExportSignalModifierQuery : IRequest<byte[]>
    {
        public Func<CommandSignalModifier, bool>? Filter { get; set; }
        public Func<CommandSignalModifier, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportSignalModifierQueryHandler :
         IRequestHandler<ExportSignalModifierQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandSignalModifier _dto = new();
        public ExportSignalModifierQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportSignalModifierQuery request, CancellationToken cancellationToken)
        {


            var allSignalModifier = (await _UnitOfWork.RepositorySignalModifier.GetAllAsync());
            var allSignalModifierDTO= _mapper.Map<List<CommandSignalModifier>>(allSignalModifier);
            if (request.Filter != null)
            {
                allSignalModifierDTO = allSignalModifierDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allSignalModifierDTO = allSignalModifierDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allSignalModifierDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandSignalModifier, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "SignalModifier");
            return result;
        }
    }
}
