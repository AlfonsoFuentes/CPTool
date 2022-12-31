using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.TestingItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.TestingItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.TestingItems.Queries.GetList
{
    public class GetTestingItemListQueryHandler : IRequestHandler<GetTestingItemsListQuery, List<CommandTestingItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetTestingItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandTestingItem>> Handle(GetTestingItemsListQuery request, CancellationToken cancellationToken)
        {
            var allTestingItem = (await _UnitOfWork.RepositoryTestingItem.GetAllAsync());
            return _mapper.Map<List<CommandTestingItem>>(allTestingItem);
        }
    }
}
