using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.PurchaseOrderItems.Queries.GetList;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrderItems.Queries.GetList
{
    public class GetPurchaseOrderItemListQueryHandler : IRequestHandler<GetPurchaseOrderItemsListQuery, List<CommandPurchaseOrderItem>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPurchaseOrderItemListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandPurchaseOrderItem>> Handle(GetPurchaseOrderItemsListQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<PurchaseOrderItem> allPurchaseOrderItem = null!;
            if (request.MWOItemId==0)
            {
                allPurchaseOrderItem = await _UnitOfWork.RepositoryPurchaseOrderItem.GetAllAsync();                
            }
            else
            {
                allPurchaseOrderItem = await _UnitOfWork.RepositoryPurchaseOrderItem.GetAllAsync(x=>x.MWOItemId== request.MWOItemId);
            }
            return _mapper.Map<List<CommandPurchaseOrderItem>>(allPurchaseOrderItem);
        }
    }
}
