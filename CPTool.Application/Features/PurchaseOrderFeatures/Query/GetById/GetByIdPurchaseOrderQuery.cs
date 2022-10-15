using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderFeatures.Query.GetById
{

    public class GetByIdPurchaseOrderQuery : GetByIdQuery, IRequest<EditPurchaseOrder>
    {
        public GetByIdPurchaseOrderQuery() { }
        
    }
    public class GetByIdPurchaseOrderQueryHandler : IRequestHandler<GetByIdPurchaseOrderQuery, EditPurchaseOrder>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdPurchaseOrderQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditPurchaseOrder> Handle(GetByIdPurchaseOrderQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<PurchaseOrder>().GetByIdAsync(request.Id);

            return _mapper.Map<EditPurchaseOrder>(table);

        }
    }
    
}
