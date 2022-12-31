using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.Gaskets.Queries.GetList;
using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.Gaskets.Queries.GetList
{
    public class GetGasketListQueryHandler : IRequestHandler<GetGasketsListQuery, List<CommandGasket>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetGasketListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandGasket>> Handle(GetGasketsListQuery request, CancellationToken cancellationToken)
        {
            var allGasket = (await _UnitOfWork.RepositoryGasket.GetAllAsync());
            return _mapper.Map<List<CommandGasket>>(allGasket);
        }
    }
}
