using CPtool.ExtensionMethods;
using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Enums;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate
{
    public class CommandTaks : CommandBase, IRequest<TaksCommandResponse>
    {


        public int? MWOId => MWO == null ? null : MWO.Id;
        public CommandMWO? MWO { get; set; }
        [Report]
        public string MWOName => MWO == null ? "" : MWO!.Name;
        public CommandMWOItem? MWOItem { get; set; }
        public int? MWOItemId => MWOItem == null ? null : MWOItem.Id;
        [Report]
        public string MWOItemName => MWOItem == null ? "" : MWOItem!.Name;
        [Report]
        public string MWOItemTagId => MWOItem == null ? "" : MWOItem!.TagId;
        public CommandPurchaseOrder? PurchaseOrder { get; set; }
        public int? PurchaseOrderId => PurchaseOrder == null ? null : PurchaseOrder.Id;
        [Report]
        public string PurchaseOrderName => PurchaseOrder == null ? "" : PurchaseOrder!.Name;
        [Report]
        public string PurchaseOrderPONumber => PurchaseOrder == null ? "" : PurchaseOrder!.PONumber;
        public CommandDownPayment? DownPayment { get; set; }
        public int? DownpaymentId => DownPayment == null ? null : DownPayment.Id;
        [Report]
        public string DownpaymentName => DownPayment == null ? "" : DownPayment!.DownpaymentName;
        [Report]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Report]
        public DateTime? ExpectedDate { get; set; } = DateTime.Now;
        [Report]
        public DateTime CompletionDate { get; set; }
        [Report]
        public string TaksStatusName => TaksStatus.ToString();
        public TaksStatus TaksStatus { get; set; } = TaksStatus.Draft;
        [Report]
        public string TaksTypeName => TaksType.ToString();
        public TaksType TaksType { get; set; }
        [Report]
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

        string GetNameFromPurchaseOrder(CommandPurchaseOrder command) =>
               command.PurchaseOrderStatus switch
               {
                   PurchaseOrderApprovalStatus.Ordering => $"Create PO from {command!.PurchaseRequisition}",
                   PurchaseOrderApprovalStatus.Draft => "",
                   PurchaseOrderApprovalStatus.Created => command!.pBrand!.BrandType == BrandType.Brand ?
                   $"Receive {command!.PONumber} from {command!.pSupplier!.Name} {command!.Name}" :
                   $"Install {command!.PONumber} from {command!.pSupplier!.Name} {command!.Name}",
                   PurchaseOrderApprovalStatus.Received => $"Install {command!.PONumber} from {command!.pSupplier!.Name} {command!.Name}",
                   PurchaseOrderApprovalStatus.Installed => $"Close {command!.PONumber} {command!.Name}",
                   PurchaseOrderApprovalStatus.Closed => $"No actions {command!.PONumber} {command!.Name}",
                   _ => "",
               };

        string GetNameFromDownPayment(CommandDownPayment command) =>
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