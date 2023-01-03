using CPtool.ExtensionMethods;
using CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Enums;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate
{
    public class CommandDownPayment : CommandBase, IRequest<DownPaymentCommandResponse>
    {

        public int? PurchaseOrderId => PurchaseOrder?.Id == 0 ? null : PurchaseOrder?.Id;
        public CommandPurchaseOrder? PurchaseOrder { get; set; }
      
        public string PurchaseOrderName => PurchaseOrder == null ? "" : PurchaseOrder!.Name;
       
        public string PurchaseOrderPO => PurchaseOrder == null ? "" : PurchaseOrder!.PONumber;

        public string PurchaseorderMWOName => PurchaseOrder!.MWO == null ? "" : PurchaseOrder.MWO.Name;
        public string PurchaseOrderSupplier => PurchaseOrder!.pSupplier == null ? "" : PurchaseOrder!.pSupplier!.Name;
 
        public string PurchaseOrderSupplierVendorCode => PurchaseOrder!.pSupplier == null ? "" : PurchaseOrder!.pSupplier!.VendorCode!;
        public string RequestDateText  => RequestDate.ToShortDateString();
        public string RealDateText => RealDate==null?"": RealDate!.Value.ToShortDateString();
        public DateTime RequestDate { get; set; } = DateTime.Now;
     
        public string? ManagerEmail { get; set; } = "";
  
        public string? CBSRequesText { get; set; } = "";
 
        public string? CBSRequesNo { get; set; } = "";
 
        public string? ProformaInvoice { get; set; } = "";
     
        public string DownpaymentStatusName => DownpaymentStatus.ToString();
        public DownpaymentStatus DownpaymentStatus { get; set; } = DownpaymentStatus.Draft;
 
        public string? Payterms { get; set; } = "";
   
        public DateTime? DownPaymentDueDate { get; set; }
   
        public DateTime? DeliveryDueDate { get; set; }
      
        public DateTime? RealDate { get; set; }
    
        public double Percentage { get; set; }
   
        public double DownPaymentAmount => Percentage * PurchaseOrder!.PrizeCurrency / 100;
      
        public string? DownpaymentDescrption { get; set; } = "";
       
        public string? Incotherm { get; set; } = "";
   
        public DateTime? ApprovedDate { get; set; }
   

        public string DownpaymentName { get; set; } = "";


        public List<CommandTaks>? Taks { get; set; }

        public CommandTaks? CommandTaks => Taks!.Count == 0 ? null : Taks.FirstOrDefault();


    }

}
