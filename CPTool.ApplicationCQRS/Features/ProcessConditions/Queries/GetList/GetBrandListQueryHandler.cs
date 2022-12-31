using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.ProcessConditions.Queries.GetList;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.ProcessConditions.Queries.GetList
{
    public class GetProcessConditionListQueryHandler : IRequestHandler<GetProcessConditionsListQuery, List<CommandProcessCondition>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetProcessConditionListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandProcessCondition>> Handle(GetProcessConditionsListQuery request, CancellationToken cancellationToken)
        {
            var allProcessCondition = (await _UnitOfWork.RepositoryProcessCondition.GetAllAsync());
            return _mapper.Map<List<CommandProcessCondition>>(allProcessCondition);
        }
    }
}
