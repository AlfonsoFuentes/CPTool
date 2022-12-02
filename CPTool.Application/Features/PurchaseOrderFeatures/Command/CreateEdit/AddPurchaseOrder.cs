

using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit
{
    public class AddPurchaseOrder : AddCommand
    {
        public int? pBrandId { get; set; }
        public int? pSupplierId { get; set; }

        public int? MWOId { get; set; }
        public string PurchaseRequisition { get; set; } = "";

        public DateTime POCreatedDate { get; set; }
        public DateTime POReceivedDate { get; set; }
        public DateTime POInstalledDate { get; set; }
        public DateTime POEstimatedDate { get; set; }
        public DateTime POOrderingdDate { get; set; }
        public string PONumber { get; set; } = "";
        public string SPL { get; set; } = "";
        public string TaxCode { get; set; } = "";

        public PurchaseOrderStatus PurchaseOrderStatus { get; set; }
        public Currency Currency { get; set; } = Currency.COP;
        public DateTime CurrencyDate { get; set; }
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }
        public List<AddPurchaseOrderItem> PurchaseOrderItems { get; set; } = new();
        public List<AddDownPayment>? DownPayments { get; set; }
        public List<AddTaks>? Taks { get; set; }
    }

}
