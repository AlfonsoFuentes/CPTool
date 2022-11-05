
using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;


namespace CPTool.Application.Features.DownPaymentFeatures.Query.GetList
{

    public class GetDownPaymentListQuery : GetListQuery, IRequest<List<EditDownPayment>>
    {


        public override bool FilterFunc(EditCommand element1, string searchString)
        {
            var element = element1 as EditDownPayment;
            var retorno = element!.DownpaymentName.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.PurchaseOrder!.PONumber.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.PurchaseOrder!.pSupplier!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.PurchaseOrder!.MWO!.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.PurchaseOrder!.MWO!.CECName!.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.DownpaymentStatus.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.CBSRequesNo!.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
            element.PurchaseOrder!.pBrand!.Name.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase);
            return retorno;
        }

    }
    public class GetUnitaryBasePrizeListQueryHandler :
          GetListQueryHandler<EditDownPayment, DownPayment, GetDownPaymentListQuery>, 
        IRequestHandler<GetDownPaymentListQuery, List<EditDownPayment>>
    {


        public GetUnitaryBasePrizeListQueryHandler(IUnitOfWork unitofwork,
            IMapper mapper) : base(unitofwork, mapper) { }
    }
}
