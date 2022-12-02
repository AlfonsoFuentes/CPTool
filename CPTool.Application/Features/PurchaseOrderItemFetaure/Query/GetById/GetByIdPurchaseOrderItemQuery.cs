using CPTool.Application.Features.MeasuredVariableFeatures.CreateEdit;
using CPTool.Application.Features.MeasuredVariableFeatures.Query.GetById;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;


namespace CPTool.Application.Features.PurchaseOrderItemFeatures.Query.GetById
{

    public class GetByIdPurchaseOrderItemQuery : GetByIdQuery, IRequest<EditPurchaseOrderItem>
    {
        public GetByIdPurchaseOrderItemQuery() { }

    }
    public class GetByIdPurchaseOrderItemQueryHandler :
         GetByIdQueryHandler<EditPurchaseOrderItem, PurchaseOrderItem, GetByIdPurchaseOrderItemQuery>,
        IRequestHandler<GetByIdPurchaseOrderItemQuery, EditPurchaseOrderItem>
    {


        public GetByIdPurchaseOrderItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper) { }
        public override async Task<EditPurchaseOrderItem> Handle(GetByIdPurchaseOrderItemQuery request, CancellationToken cancellationToken)
        {
            EditPurchaseOrderItem result = new();
            if (request.Id != 0)
            {
                var table = await _unitofwork.Repository<PurchaseOrderItem>().GetByIdAsync(request.Id);

                result = _mapper.Map<EditPurchaseOrderItem>(table);
            }



            return result;

        }
    }

}
