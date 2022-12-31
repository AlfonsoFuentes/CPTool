using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.Readouts.Queries.ExportExcel
{
    public class ExportReadoutQuery : IRequest<byte[]>
    {
        public Func<CommandReadout, bool>? Filter { get; set; }
        public Func<CommandReadout, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportReadoutQueryHandler :
         IRequestHandler<ExportReadoutQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandReadout _dto = new();
        public ExportReadoutQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportReadoutQuery request, CancellationToken cancellationToken)
        {


            var allReadout = (await _UnitOfWork.RepositoryReadout.GetAllAsync());
            var allReadoutDTO= _mapper.Map<List<CommandReadout>>(allReadout);
            if (request.Filter != null)
            {
                allReadoutDTO = allReadoutDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allReadoutDTO = allReadoutDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allReadoutDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandReadout, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "Readout");
            return result;
        }
    }
}
