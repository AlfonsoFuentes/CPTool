using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.UserRequirements.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.UserRequirements.Queries.ExportExcel
{
    public class ExportUserRequirementQuery : IRequest<byte[]>
    {
        public Func<CommandUserRequirement, bool>? Filter { get; set; }
        public Func<CommandUserRequirement, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportUserRequirementQueryHandler :
         IRequestHandler<ExportUserRequirementQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandUserRequirement _dto = new();
        public ExportUserRequirementQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportUserRequirementQuery request, CancellationToken cancellationToken)
        {


            var allUserRequirement = (await _UnitOfWork.RepositoryUserRequirement.GetAllAsync());
            var allUserRequirementDTO= _mapper.Map<List<CommandUserRequirement>>(allUserRequirement);
            if (request.Filter != null)
            {
                allUserRequirementDTO = allUserRequirementDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allUserRequirementDTO = allUserRequirementDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allUserRequirementDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandUserRequirement, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "UserRequirement");
            return result;
        }
    }
}
