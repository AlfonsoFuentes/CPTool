using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.TaksFeatures.CreateEdit
{
    public class EditTaks : EditCommand, IRequest<Result<int>>
    {
        public int? MWOId => MWO == null ? null : MWO.Id;
        public EditMWO? MWO { get; set; }
        public EditMWOItem? MWOItem { get; set; }
        public int? MWOItemId => MWOItem == null ? null : MWOItem.Id;

        public EditPurchaseOrder? PurchaseOrder { get; set; }
        public int? PurchaseOrderId => PurchaseOrder == null ? null : PurchaseOrder.Id;

        public EditDownPayment? DownPayment { get; set; }
        public int? DownpaymentId => DownPayment == null ? null : DownPayment.Id;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ExpectedDate { get; set; } = DateTime.Now;
        public DateTime CompletionDate { get; set; }
        public TaksStatus TaksStatus { get; set; } = TaksStatus.Draft;
        public TaksType TaksType { get; set; }

    }
   
}