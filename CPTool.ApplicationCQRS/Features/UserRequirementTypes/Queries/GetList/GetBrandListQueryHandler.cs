using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.UserRequirementTypes.Queries.GetList;
using CPTool.ApplicationCQRS.Features.UserRequirementTypes.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.UserRequirementTypes.Queries.GetList
{
    public class GetUserRequirementTypeListQueryHandler : IRequestHandler<GetUserRequirementTypesListQuery, List<CommandUserRequirementType>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetUserRequirementTypeListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandUserRequirementType>> Handle(GetUserRequirementTypesListQuery request, CancellationToken cancellationToken)
        {
            var allUserRequirementType = (await _UnitOfWork.RepositoryUserRequirementType.GetAllAsync());
            return _mapper.Map<List<CommandUserRequirementType>>(allUserRequirementType);
        }
    }
}
