
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.Query.GetList;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Query.GetList
{

    public class GetPurchaseOrderMWOItemListQuery : GetListQuery, IRequest<List<EditPurchaseOrderMWOItem>>
    {



    }
    public class GetPurchaseOrderMWOItemListQueryHandler :
         GetListQueryHandler<EditPurchaseOrderMWOItem, PurchaseOrderMWOItem, GetPurchaseOrderMWOItemListQuery>, 
        IRequestHandler<GetPurchaseOrderMWOItemListQuery, List<EditPurchaseOrderMWOItem>>
    {
        public GetPurchaseOrderMWOItemListQueryHandler(IUnitOfWork unitofwork, IMapper mapper) : base(unitofwork, mapper)
        {
        }

       
    }
}
