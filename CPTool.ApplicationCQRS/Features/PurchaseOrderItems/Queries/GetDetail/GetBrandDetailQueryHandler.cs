using AutoMapper;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;

using CPTool.ApplicationCQRS.Contracts.Persistence;


using MediatR;

namespace CPTool.ApplicationCQRSFeatures.PurchaseOrderItems.Queries.GetDetail
{
    public class GetPurchaseOrderItemDetailQueryHandler : IRequestHandler<GetPurchaseOrderItemDetailQuery, CommandPurchaseOrderItem>
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public GetPurchaseOrderItemDetailQueryHandler(IMapper mapper, IUnitOfWork UnitofWork)
        {
            _mapper = mapper;
            _UnitOfWork = UnitofWork;
        }

        public async Task<CommandPurchaseOrderItem> Handle(GetPurchaseOrderItemDetailQuery request, CancellationToken cancellationToken)
        {
            var table = await _UnitOfWork.RepositoryPurchaseOrderItem.GetByIdAsync(request.Id);
            var dto = _mapper.Map<CommandPurchaseOrderItem>(table);
            return dto;
        }
    }
}
