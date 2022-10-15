using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Query.GetById
{

    public class GetByIdPurchaseOrderMWOItemQuery : GetByIdQuery, IRequest<EditPurchaseOrderMWOItem>
    {
        public GetByIdPurchaseOrderMWOItemQuery() { }
       
    }
    public class GetByIdPurchaseOrderMWOItemQueryHandler : IRequestHandler<GetByIdPurchaseOrderMWOItemQuery, EditPurchaseOrderMWOItem>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetByIdPurchaseOrderMWOItemQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<EditPurchaseOrderMWOItem> Handle(GetByIdPurchaseOrderMWOItemQuery request, CancellationToken cancellationToken)
        {
            var table = await _unitofwork.Repository<PurchaseOrderMWOItem>().GetByIdAsync(request.Id);

            return _mapper.Map<EditPurchaseOrderMWOItem>(table);

        }
    }
    
}
