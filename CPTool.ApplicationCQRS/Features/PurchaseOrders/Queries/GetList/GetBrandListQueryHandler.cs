﻿using AutoMapper;

using CPTool.Persistence.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;
using CPTool.ApplicationCQRS.Contracts.Persistence;

using MediatR;
using CPTool.ApplicationCQRSFeatures.PurchaseOrders.Queries.GetList;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;

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
            if (request.MWOId == 0)
            {
                allPurchaseOrder = (await _UnitOfWork.RepositoryPurchaseOrder.GetAllAsync());
            }
            else
            {
                allPurchaseOrder = (await _UnitOfWork.RepositoryPurchaseOrder.GetAllAsync(s => s.MWOId == request.MWOId));
            }

            return _mapper.Map<List<CommandPurchaseOrder>>(allPurchaseOrder);
        }
    }
}
