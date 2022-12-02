

using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit
{
    public class EditPurchaseOrderItem : EditCommand, IRequest<Result<int>>
    {
        public override string Name { get => name; set => base.Name = name; }
        string name => MWOItem != null ? MWOItem.Name : "";
        public int? PurchaseOrderId => PurchaseOrder?.Id == 0 ? null : PurchaseOrder?.Id;
        public EditPurchaseOrder? PurchaseOrder { get; set; }
        public int? MWOItemId => MWOItem?.Id == 0 ? null : MWOItem?.Id;
        public EditMWOItem? MWOItem { get; set; }
        public Currency Currency => PurchaseOrder!.Currency;
        public double PrizeCurrency { get; set; }

        public double PrizeUSD
        {
            get => Currency == Currency.USD ? PrizeCurrency :
                Currency == Currency.COP ? Math.Round(PrizeCurrency / PurchaseOrder!.USDCOP, 2) : Math.Round(PrizeCurrency / PurchaseOrder!.USDEUR, 2);

        }

        public double Tax { get; set; } = 0.19;
        public double PrizeCurrencyTax => Tax * PrizeCurrency;

        public double TotalPrizeCurrency => PrizeCurrency + PrizeCurrencyTax;
        public double ValueExchangeRate => Currency == Currency.EUR ? Currency == Currency.USD ? 1 : PurchaseOrder!.USDEUR : PurchaseOrder!.USDCOP;



    }
}
