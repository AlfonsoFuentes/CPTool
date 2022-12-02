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

        public override string Name
        {
            get
            {
                if (TaksType == TaksType.Automatic)
                {
                    if (PurchaseOrder != null)
                    {
                        

                        base.Name = GetNameFromPurchaseOrder(PurchaseOrder);
                    }
                    if (DownPayment != null)
                    {

                        base.Name = GetNameFromDownPayment(DownPayment);
                    }
                }
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }

        string GetNameFromPurchaseOrder(EditPurchaseOrder command) =>
               command.PurchaseOrderStatus switch
               {
                   PurchaseOrderStatus.Ordering => $"Create PO from {command!.PurchaseRequisition}",
                   PurchaseOrderStatus.Draft => "",
                   PurchaseOrderStatus.Created => command!.pBrand!.BrandType == BrandType.Brand ?
                   $"Receive {command!.PONumber} from {command!.pSupplier!.Name} {command!.Name}" :
                   $"Install {command!.PONumber} from {command!.pSupplier!.Name} {command!.Name}",
                   PurchaseOrderStatus.Received => $"Install {command!.PONumber} from {command!.pSupplier!.Name} {command!.Name}",
                   PurchaseOrderStatus.Installed => $"Close {command!.PONumber} {command!.Name}",
                   PurchaseOrderStatus.Closed => $"No actions {command!.PONumber} {command!.Name}",
                   _ => "",
               };

        string GetNameFromDownPayment(EditDownPayment command) =>
            command.DownpaymentStatus switch
            {
                DownpaymentStatus.Draft => $"Create Downpayment {command!.DownpaymentName}",
                DownpaymentStatus.Created => $"Approve Downpayment {command!.DownpaymentName} for {command!.PurchaseOrder!.pSupplier!.Name}",
                DownpaymentStatus.Approved => $"Pay Downpayment {command!.DownpaymentName} for {command!.PurchaseOrder!.pSupplier!.Name}",
                DownpaymentStatus.Paid => $"Confirm paid Downpayment {command!.DownpaymentName} for {command!.PurchaseOrder!.pSupplier!.Name}",
                DownpaymentStatus.Rejected => $"Rejected paid Downpayment {command!.DownpaymentName} for {command!.PurchaseOrder!.pSupplier!.Name}",

                DownpaymentStatus.Closed => $"Closed Downpayment {command!.DownpaymentName} for {command!.PurchaseOrder!.pSupplier!.Name}",
                _ => throw new NotImplementedException(),
            };


    }

}