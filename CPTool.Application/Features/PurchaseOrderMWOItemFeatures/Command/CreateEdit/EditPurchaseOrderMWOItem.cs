using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit
{
    public class EditPurchaseOrderMWOItem : EditCommand, IRequest<Result<int>>
    {
        public int? PurchaseOrderId => PurchaseOrder?.Id == 0 ? null : PurchaseOrder?.Id;

        public EditPurchaseOrder? PurchaseOrder { get; set; }

        public Currency Currency { get; set; } = Currency.COP;
        public double PrizeCurrency { get; set; }
        public double PrizeUSD { get; set; }
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }

        public double Tax { get; set; }
        public double PrizeCurrencyTax { get; set; }
        public double TotalPrizeCurrency { get; set; }

    }
}
