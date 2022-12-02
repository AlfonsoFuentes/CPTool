

using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderItemFeatures.Query.GetList
{

    public class GetPurchaseOrderItemListQuery : GetListQuery, IRequest<List<EditPurchaseOrderItem>>
    {



    }
    public class GetMWOItemCurrencyValueListQueryHandler :
        GetListQueryHandler<EditPurchaseOrderItem, PurchaseOrderItem, GetPurchaseOrderItemListQuery>,
        IRequestHandler<GetPurchaseOrderItemListQuery, List<EditPurchaseOrderItem>>
    {
        public GetMWOItemCurrencyValueListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }

        public override async Task<List<EditPurchaseOrderItem>> Handle(GetPurchaseOrderItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PurchaseOrderItem>().GetAllAsync();


            var retorno = _mapper.Map<List<EditPurchaseOrderItem>>(list);
            return retorno;

        }
    }
}
