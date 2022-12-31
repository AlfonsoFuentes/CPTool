using AutoMapper;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.ApplicationCQRS.Features.UserRequirementTypes.Queries.ExportExcel
{
    public class ExportUserRequirementTypeQuery : IRequest<byte[]>
    {
        public Func<CommandUserRequirementType, bool>? Filter { get; set; }
        public Func<CommandUserRequirementType, bool>? OrderBy { get; set; }
        public string Keyword { get; set; } = String.Empty;
    }
    public class ExportUserRequirementTypeQueryHandler :
         IRequestHandler<ExportUserRequirementTypeQuery, byte[]>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IExcelService _excelService;

        private readonly CommandUserRequirementType _dto = new();
        public ExportUserRequirementTypeQueryHandler(
            IUnitOfWork UnitOfWork,
            IMapper mapper,
            IExcelService excelService
            )
        {

            _mapper = mapper;
            _excelService = excelService;
            _UnitOfWork = UnitOfWork;


        }

        public async Task<byte[]> Handle(ExportUserRequirementTypeQuery request, CancellationToken cancellationToken)
        {


            var allUserRequirementType = (await _UnitOfWork.RepositoryUserRequirementType.GetAllAsync());
            var allUserRequirementTypeDTO= _mapper.Map<List<CommandUserRequirementType>>(allUserRequirementType);
            if (request.Filter != null)
            {
                allUserRequirementTypeDTO = allUserRequirementTypeDTO!.Where(request.Filter).ToList();
            }
            if (request.OrderBy != null)
            {
                allUserRequirementTypeDTO = allUserRequirementTypeDTO!.OrderBy(request.OrderBy).ToList();
            }

            var data2 = allUserRequirementTypeDTO.AsEnumerable();
            var result = await _excelService.ExportAsync(data2,
                new Dictionary<string, Func<CommandUserRequirementType, object?>>()
                {
                    // TODO: Define the fields that should be exported, for example:
                    {"Id",item => item.Id},
                    { "Name",item => item.Name}

                }
                , "UserRequirementType");
            return result;
        }
    }
}
