
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using CPTool.Domain.Enums;

namespace CPTool.Application.Features.DownPaymentFeatures.CreateEdit
{
    public class EditDownPayment : EditCommand, IRequest<Result<int>>
    {
       
        public int? PurchaseOrderId => PurchaseOrder?.Id == 0 ? null : PurchaseOrder?.Id;
        public EditPurchaseOrder? PurchaseOrder { get; set; }
        [Report(Order = 3)]
        public string PurchaseOrderName => PurchaseOrder==null?"": PurchaseOrder!.Name;
        [Report(Order = 4)]
        public string PurchaseOrderPO => PurchaseOrder == null ? "" : PurchaseOrder!.PONumber;
        [Report(Order = 5)]
        public string PurchaseOrderSupplier => PurchaseOrder!.pSupplier == null ? "" : PurchaseOrder!.pSupplier!.Name;
        [Report(Order = 6)]
        public string PurchaseOrderSupplierVendorCode => PurchaseOrder!.pSupplier == null ? "" : PurchaseOrder!.pSupplier!.VendorCode!;
        [Report(Order = 7)]
        public DateTime RequestDate { get; set; } = DateTime.Now;
        [Report(Order = 8)]
        public string? ManagerEmail { get; set; } = "";
        [Report(Order = 9)]
        public string? CBSRequesText { get; set; } = "";
        [Report(Order = 10)]
        public string? CBSRequesNo { get; set; } = "";
        [Report(Order = 11)]
        public string? ProformaInvoice { get; set; } = "";
        [Report(Order = 12)]
        public string DownpaymentStatusName => DownpaymentStatus.ToString();
        public DownpaymentStatus DownpaymentStatus { get; set; } = DownpaymentStatus.Draft;
        [Report(Order = 13)]
        public string? Payterms { get; set; } = "";
        [Report(Order = 14)]
        public DateTime? DownPaymentDueDate { get; set; }
        [Report(Order = 15)]
        public DateTime? DeliveryDueDate { get; set; }
        [Report(Order = 16)]
        public DateTime? RealDate { get; set; }
        [Report(Order = 17)]
        public double Percentage { get; set; }
        [Report(Order = 18)]
        public double DownPaymentAmount => Percentage * PurchaseOrder!.PrizeCurrency/100;
        [Report(Order = 19)]
        public string? DownpaymentDescrption { get; set; } = "";
        [Report(Order = 20)]
        public string? Incotherm { get; set; } = "";
        [Report(Order = 21)]
        public DateTime? ApprovedDate { get; set; }
        [Report(Order = 22)]

        public string DownpaymentName { get; set; } = "";
       

        public List<EditTaks>? Taks { get; set; }

        public EditTaks? EditTaks => Taks!.Count == 0 ? null : Taks.FirstOrDefault();
    }
}
