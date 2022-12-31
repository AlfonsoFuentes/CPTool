using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.PipingItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.PipingItems.Queries.GetList
{
    public class GetPipingItemListQueryHandler : IRequestHandler<GetPipingItemsListQuery, List<CommandPipingItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPipingItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandPipingItem>> Handle(GetPipingItemsListQuery request, CancellationToken cancellationToken)
        {
            var allPipingItem = (await _UnitOfWork.RepositoryPipingItem.GetAllAsync());
            return _mapper.Map<List<CommandPipingItem>>(allPipingItem);
        }
    }
}
