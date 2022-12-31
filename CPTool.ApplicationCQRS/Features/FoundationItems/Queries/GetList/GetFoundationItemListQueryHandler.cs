using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.FoundationItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.FoundationItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.FoundationItems.Queries.GetList
{
    public class GetFoundationItemListQueryHandler : IRequestHandler<GetFoundationItemsListQuery, List<CommandFoundationItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetFoundationItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandFoundationItem>> Handle(GetFoundationItemsListQuery request, CancellationToken cancellationToken)
        {
            var allFoundationItem = (await _UnitOfWork.RepositoryFoundationItem.GetAllAsync());
            return _mapper.Map<List<CommandFoundationItem>>(allFoundationItem);
        }
    }
}
