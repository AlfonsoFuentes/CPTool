using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.PaintingItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.PaintingItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.PaintingItems.Queries.GetList
{
    public class GetPaintingItemListQueryHandler : IRequestHandler<GetPaintingItemsListQuery, List<CommandPaintingItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPaintingItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandPaintingItem>> Handle(GetPaintingItemsListQuery request, CancellationToken cancellationToken)
        {
            var allPaintingItem = (await _UnitOfWork.RepositoryPaintingItem.GetAllAsync());
            return _mapper.Map<List<CommandPaintingItem>>(allPaintingItem);
        }
    }
}
