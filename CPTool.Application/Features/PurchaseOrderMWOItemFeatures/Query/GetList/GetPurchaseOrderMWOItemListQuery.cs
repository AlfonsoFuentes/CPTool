
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Query.GetList
{

    public class GetPurchaseOrderMWOItemListQuery : GetListQuery, IRequest<List<AddEditPurchaseOrderMWOItemCommand>>
    {



    }
    public class GetPurchaseOrderMWOItemListQueryHandler : IRequestHandler<GetPurchaseOrderMWOItemListQuery, List<AddEditPurchaseOrderMWOItemCommand>>
    {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitofwork;
        public GetPurchaseOrderMWOItemListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        public async Task<List<AddEditPurchaseOrderMWOItemCommand>> Handle(GetPurchaseOrderMWOItemListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitofwork.Repository<PurchaseOrderMWOItem>().GetAllAsync();

            return _mapper.Map<List<AddEditPurchaseOrderMWOItemCommand>>(list);

        }
    }
}
