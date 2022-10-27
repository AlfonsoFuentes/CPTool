using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderFeatures.Query.GetList
{

    public class GetPurchaseOrderListQuery : GetListQuery, IRequest<List<EditPurchaseOrder>>
    {

        public override bool FilterFunc(EditCommand element1, string searchString)
        {
            var element = element1 as EditPurchaseOrder;
            var retorno = element!.PurchaseRequisition.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.PONumber.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.MWO!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.MWO!.CECName!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.PurchaseOrderStatus.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.pSupplier!.Name.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.pBrand!.Name.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase);
            return retorno;
        }

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
            list = list.OrderBy(x => x.PurchaseOrderStatus).ToList();
            return _mapper.Map<List<EditPurchaseOrder>>(list);

        }
    }
}
