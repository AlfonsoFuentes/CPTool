using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderFeatures.Query.GetList
{

    public class GetPurchaseOrderListQuery : GetListQuery, IRequest<List<EditPurchaseOrder>>
    {
       

       
    }
    public class GetPurchaseOrderListQueryHandler : IRequestHandler<GetPurchaseOrderListQuery, List<EditPurchaseOrder>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPurchaseOrderListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<EditPurchaseOrder>> Handle(GetPurchaseOrderListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PurchaseOrder>().GetAllAsync();

            return _mapper.Map<List<EditPurchaseOrder>>(list);

        }
    }
}
