using CPTool.Application.Features.BrandFeatures;
using CPTool.Application.Features.BrandFeatures.CreateEdit;

using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;

using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;

using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;

using CPTool.Domain.Enums;


namespace CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit
{
    public class EditPurchaseOrder : EditCommand, IRequest<Result<int>>
    {
        [Report(Order = 3)]
        public DateTime? CurrencyDate { get; set; } = DateTime.UtcNow;
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }
        [Report(Order = 4)]
        public string TaxCode { get; set; } = "";
        [Report(Order = 5)]
        public string SPL { get; set; } = "";
        [Report(Order = 6)]
        public string VendorCode => pSupplier == null ? "" : pSupplier!.VendorCode!;
        [Report(Order = 7)]
        public string CostCenter { get; set; } = "";


       
        [Report(Order = 10)]
        public string PurchaseRequisition { get; set; } = "";

        public DateTime POCreatedDate { get; set; } = DateTime.Now;
        public DateTime POReceivedDate { get; set; }
        public DateTime POInstalledDate { get; set; }
        public DateTime? POEstimatedDate { get; set; }
        public DateTime POOrderingdDate { get; set; }
        [Report(Order = 11)]
        public string PONumber { get; set; } = "";

        [Report]
        public string PurchaseOrderApprovalStatusName => PurchaseOrderStatus.ToString();
        public PurchaseOrderApprovalStatus PurchaseOrderStatus { get; set; } = PurchaseOrderApprovalStatus.Draft;

        public string PrizeUSDValue => String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", PrizeUSD);
        public double PrizeUSD => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(x => x.PrizeUSD);
        [Report]
        public string PrizeCurrencyValue => String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", PrizeCurrency);
        [Report]
        public double PrizeCurrency => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(x => x.PrizeCurrency);
        [Report]
        public double PrizeCurrencyTax => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(x => x.PrizeCurrencyTax);
        [Report]
        public double TotalPrizeCurrency => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(x => x.TotalPrizeCurrency);
        [Report]
        public Currency Currency { get; set; } = Currency.COP;
        public int? MWOId => MWO == null ? null : MWO?.Id;
        public EditMWO MWO { get; set; } = null!;
        [Report]
        public string MWOName => MWO!.Name;
        public EditPurchaseOrderItem PurchaseOrderItem { get; set; } = new();
        public int? pBrandId => pBrand?.Id == 0 ? null : pBrand?.Id;
        public EditBrand? pBrand { get; set; } = new();
        [Report]
        public string BrandName => pBrand!.Name;
        public int? pSupplierId => pSupplier?.Id == 0 ? null : pSupplier?.Id;
        public EditSupplier? pSupplier { get; set; } = new();

        [Report]
        public string SupplierName => pSupplier!.Name;

        public List<EditPurchaseOrderItem> PurchaseOrderItems { get; set; } = new();
        public List<EditDownPayment>? DownPayments { get; set; }
        public List<EditTaks>? Taks { get; set; }

        public EditTaks? EditTaks => Taks!.Count == 0 ? null : Taks.FirstOrDefault();

        public double ActualValue => (PurchaseOrderItems.Count == 0  )? 0 : StatusPurchaseOrder == StatusPurchaseOrder.Actual ? PurchaseOrderItems.Sum(x => x.PrizeUSD) : 0;
        public double CommitmentValue => (PurchaseOrderItems.Count == 0  )? 0 : StatusPurchaseOrder == StatusPurchaseOrder.Commitment ? PurchaseOrderItems.Sum(x => x.PrizeUSD) : 0;


        public StatusPurchaseOrder StatusPurchaseOrder => GetStatusPurchaseOrder();
        StatusPurchaseOrder GetStatusPurchaseOrder()
        {
            if (pBrand != null && pBrand!.BrandType == BrandType.Brand &&
                (PurchaseOrderStatus == PurchaseOrderApprovalStatus.Received || PurchaseOrderStatus == PurchaseOrderApprovalStatus.Closed))
            {
                return StatusPurchaseOrder.Actual;
            }
            else if (pBrand != null && pBrand!.BrandType == BrandType.Service &&
                (PurchaseOrderStatus == PurchaseOrderApprovalStatus.Installed || PurchaseOrderStatus == PurchaseOrderApprovalStatus.Closed))
            {
                return StatusPurchaseOrder.Actual;
            }
            return StatusPurchaseOrder.Commitment;
        }


    }
    public enum StatusPurchaseOrder
    {
        Actual,
        Commitment
    }
}
