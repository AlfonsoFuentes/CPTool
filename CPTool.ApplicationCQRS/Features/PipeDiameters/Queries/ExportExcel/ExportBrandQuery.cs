using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Queries.ExportExcel
{
    public class ExportPipeDiameterQuery : IRequest<byte[]>
    {
        public Func<CommandPipeDiameter, bool>? Filter { get; set; }
        public Func<CommandPipeDiameter, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportPipeDiameterQueryHandler :
         IRequestHandler<ExportPipeDiameterQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandPipeDiameter _dto = new();
        public ExportPipeDiameterQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportPipeDiameterQuery request, CancellationToken cancellationToken)
        {


            var allPipeDiameter = (await _UnitOfWork.RepositoryPipeDiameter.GetAllAsync());
            var allPipeDiameterDTO= _mapper.Map<List<CommandPipeDiameter>>(allPipeDiameter);
            if (request.Filter != null)
            {
                allPipeDiameterDTO = allPipeDiameterDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allPipeDiameterDTO = allPipeDiameterDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allPipeDiameterDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandPipeDiameter, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "PipeDiameter");
            return result;
        }
    }
}
