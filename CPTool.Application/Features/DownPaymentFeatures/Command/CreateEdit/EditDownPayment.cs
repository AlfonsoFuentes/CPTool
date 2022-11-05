using CPTool.Application.Features.DeviceFunctionModifierFeatures.Query.GetById;
using CPTool.Application.Features.DeviceFunctionModifierFeatures.Query.GetList;
using CPTool.Application.Features.DownPaymentFeatures.Query.GetById;
using CPTool.Application.Features.DownPaymentFeatures.Query.GetList;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;

namespace CPTool.Application.Features.DownPaymentFeatures.CreateEdit
{
    public class EditDownPayment : EditCommand, IRequest<Result<int>>
    {
       
        public int? PurchaseOrderId => PurchaseOrder?.Id == 0 ? null : PurchaseOrder?.Id;
        public EditPurchaseOrder? PurchaseOrder { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public string? ManagerEmail { get; set; } = "";
        public string? CBSRequesText { get; set; } = "";
        public string? CBSRequesNo { get; set; } = "";
        public string? ProformaInvoice { get; set; } = "";
        public DownpaymentStatus DownpaymentStatus { get; set; } = DownpaymentStatus.Draft;
        public string? Payterms { get; set; } = "";
        public DateTime? DownPaymentDueDate { get; set; }
        public DateTime? DeliveryDueDate { get; set; }
        public DateTime? RealDate { get; set; }
        public double Percentage { get; set; }
        public double DownPaymentAmount => Percentage * PurchaseOrder!.Value/100;
        public string? DownpaymentDescrption { get; set; } = "";
        public string? Incotherm { get; set; } = "";
        public DateTime? ApprovedDate { get; set; }
       
        public string DownpaymentName { get; set; } = "";

        public List<EditTaks>? Taks { get; set; }

        public EditTaks? EditTaks => Taks!.Count == 0 ? null : Taks.FirstOrDefault();
    }
}
