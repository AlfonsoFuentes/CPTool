using AutoMapper;
using CPTool.ApplicationCQRS.Features.ProcessConditions.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.ProcessConditions.Queries.GetDetail
{
    public class GetProcessConditionDetailQueryHandler : IRequestHandler<GetProcessConditionDetailQuery, CommandProcessCondition>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetProcessConditionDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandProcessCondition> Handle(GetProcessConditionDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryProcessCondition.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandProcessCondition>(table);
            return dto;
        }
    }
}
