





using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.DownPaymentFeatures.CreateEdit
{
    public class AddDownPayment : AddCommand
    {
        public int? PurchaseOrderId { get; set; }


        public DateTime? RequestDate { get; set; }
        public string? ManagerEmail { get; set; }
        public string? CBSRequesText { get; set; }
        public string? CBSRequesNo { get; set; }
        public string? ProformaInvoice { get; set; }
        public DownpaymentStatus DownpaymentStatus { get; set; }
        public string? Payterms { get; set; }
        public DateTime? DownPaymentDueDate { get; set; }
        public DateTime? DeliveryDueDate { get; set; }
        public DateTime? RealDate { get; set; }
        public double Percentage { get; set; }
        public double DownPaymentAmount { get; set; }
        public string? DownpaymentDescrption { get; set; }
        public string? Incotherm { get; set; }
        public DateTime? ApprovedDate { get; set; }

      
    }
}
