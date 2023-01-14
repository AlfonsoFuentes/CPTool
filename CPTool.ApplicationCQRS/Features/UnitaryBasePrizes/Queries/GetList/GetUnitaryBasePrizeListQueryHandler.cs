using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.UnitaryBasePrizes.Queries.GetList;
using CPTool.ApplicationCQRS.Features.UnitaryBasePrizes.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.UnitaryBasePrizes.Queries.GetList
{
    public class GetUnitaryBasePrizeListQueryHandler : IRequestHandler<GetUnitaryBasePrizesListQuery, List<CommandUnitaryBasePrize>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetUnitaryBasePrizeListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandUnitaryBasePrize>> Handle(GetUnitaryBasePrizesListQuery request, CancellationToken cancellationToken)
        {
            var allUnitaryBasePrize = (await _UnitOfWork.RepositoryUnitaryBasePrize.GetAllAsync());
            return _mapper.Map<List<CommandUnitaryBasePrize>>(allUnitaryBasePrize);
        }
    }
}
