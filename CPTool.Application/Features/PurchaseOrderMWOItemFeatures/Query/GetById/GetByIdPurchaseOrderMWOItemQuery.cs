using CPTool.Application.Features.PropertyPackageFeatures.CreateEdit;
using CPTool.Application.Features.PropertyPackageFeatures.Query.GetById;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Query.GetById
{

    public class GetByIdPurchaseOrderMWOItemQuery : GetByIdQuery, IRequest<EditPurchaseOrderMWOItem>
    {
        public GetByIdPurchaseOrderMWOItemQuery() { }
       
    }
    public class GetByIdPurchaseOrderMWOItemQueryHandler : GetByIdQueryHandler<EditPurchaseOrderMWOItem, PurchaseOrderMWOItem, GetByIdPurchaseOrderMWOItemQuery>, 
        
        IRequestHandler<GetByIdPurchaseOrderMWOItemQuery, EditPurchaseOrderMWOItem>
    {

      
        public GetByIdPurchaseOrderMWOItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
