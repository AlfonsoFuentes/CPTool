using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.PurchaseOrders.Queries.GetList;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrders.Queries.GetList
{
    public class GetPurchaseOrderListQueryHandler : IRequestHandler<GetPurchaseOrdersListQuery, List<CommandPurchaseOrder>>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPurchaseOrderListQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<List<CommandPurchaseOrder>> Handle(GetPurchaseOrdersListQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyCollection<PurchaseOrder> allPurchaseOrder = null!;
            Func<IQueryable<PurchaseOrder>, IOrderedQueryable<PurchaseOrder>> orderBy = x => x.OrderBy(x => x.PurchaseOrderStatus);
            if (request.MWOId == 0)
            {
                allPurchaseOrder = (await _UnitOfWork.RepositoryPurchaseOrder.GetAllAsync(orderBy));
            }
            else
            {
                allPurchaseOrder = (await _UnitOfWork.RepositoryPurchaseOrder.GetAllAsync(s => s.MWOId == request.MWOId, orderBy));
            }
            var result = _mapper.Map<List<CommandPurchaseOrder>>(allPurchaseOrder);
            
            return result;
        }
      

    }
}
