using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.EngineeringCostItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.EngineeringCostItems.Queries.GetList
{
    public class GetEngineeringCostItemListQueryHandler : IRequestHandler<GetEngineeringCostItemsListQuery, List<CommandEngineeringCostItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetEngineeringCostItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandEngineeringCostItem>> Handle(GetEngineeringCostItemsListQuery request, CancellationToken cancellationToken)
        {
            var allEngineeringCostItem = (await _UnitOfWork.RepositoryEngineeringCostItem.GetAllAsync());
            return _mapper.Map<List<CommandEngineeringCostItem>>(allEngineeringCostItem);
        }
    }
}
