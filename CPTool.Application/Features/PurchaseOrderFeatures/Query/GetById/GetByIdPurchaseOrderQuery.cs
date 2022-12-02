using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;


namespace CPTool.Application.Features.PurchaseOrderFeatures.Query.GetById
{

    public class GetByIdPurchaseOrderQuery : GetByIdQuery, IRequest<EditPurchaseOrder>
    {
        public GetByIdPurchaseOrderQuery() { }
        
    }
    public class GetByIdPurchaseOrderQueryHandler : 
        GetByIdQueryHandler<EditPurchaseOrder, PurchaseOrder, GetByIdPurchaseOrderQuery>, 
        IRequestHandler<GetByIdPurchaseOrderQuery, EditPurchaseOrder>
    {

        public GetByIdPurchaseOrderQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper):base(unitofwork, mapper) { }
    }
    
}
