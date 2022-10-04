using CPTool.Application.Features.PurchaseOrderFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderFeatures.Query.GetList
{

    public class GetPurchaseOrderListQuery : GetListQuery, IRequest<List<AddEditPurchaseOrderCommand>>
    {
       

       
    }
    public class GetPurchaseOrderListQueryHandler : IRequestHandler<GetPurchaseOrderListQuery, List<AddEditPurchaseOrderCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPurchaseOrderListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditPurchaseOrderCommand>> Handle(GetPurchaseOrderListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PurchaseOrder>().GetAsync(null!,null!,true,true);

            return _mapper.Map<List<AddEditPurchaseOrderCommand>>(list);

        }
    }
}
