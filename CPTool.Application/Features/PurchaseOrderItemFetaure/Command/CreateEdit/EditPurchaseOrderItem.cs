

using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;
using CPTool.Domain.Entities;
using CPTool.Domain.Enums;

namespace CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit
{
    public class EditPurchaseOrderItem : EditCommand, IRequest<Result<int>>
    {
        [Report]
        public override string Name { get => name; set => base.Name = name; }
        string name => MWOItem != null ? MWOItem.Name : "";
        public int? PurchaseOrderId => PurchaseOrder?.Id == 0 ? null : PurchaseOrder?.Id;
        public EditPurchaseOrder? PurchaseOrder { get; set; }
        [Report]
        public string PurchaseorderName => PurchaseOrder==null?"": PurchaseOrder!.Name;
        [Report]
        public string PurchaseorderPONumber => PurchaseOrder == null ? "" : PurchaseOrder!.PONumber;
        [Report]
        public string PurchaseorderSupplier => PurchaseOrder!.pSupplier == null ? "" : PurchaseOrder!.pSupplier!.Name;
        public int? MWOItemId => MWOItem?.Id == 0 ? null : MWOItem?.Id;
        public EditMWOItem? MWOItem { get; set; }
        [Report]
        public string MWOItemName => MWOItem == null ? "" : MWOItem!.Name;
        [Report]
        public string MWOItemTag => MWOItem == null ? "" : MWOItem!.TagId;
        [Report]
        public string CurrencyName => Currency.ToString();
        public Currency Currency => PurchaseOrder!.Currency;
        [Report]
        public double PrizeCurrency { get; set; }
        [Report]
        public double PrizeUSD
        {
            get => Currency == Currency.USD ? PrizeCurrency :
                Currency == Currency.COP ? Math.Round(PrizeCurrency / PurchaseOrder!.USDCOP, 2) : Math.Round(PrizeCurrency / PurchaseOrder!.USDEUR, 2);

        }
        [Report]
        public double Tax { get; set; } = 0.19;
        [Report]
        public double PrizeCurrencyTax => Tax * PrizeCurrency;
        [Report]
        public double TotalPrizeCurrency => PrizeCurrency + PrizeCurrencyTax;
        [Report]
        public double ValueExchangeRate => Currency == Currency.EUR ? Currency == Currency.USD ? 1 : PurchaseOrder!.USDEUR : PurchaseOrder!.USDCOP;

        public double ActualValue => (PurchaseOrder!.StatusPurchaseOrder==StatusPurchaseOrder.Actual) ? PrizeUSD : 0;
        public double CommitmentValue => (PurchaseOrder!.StatusPurchaseOrder == StatusPurchaseOrder.Commitment) ? PrizeUSD : 0;

    }

}
