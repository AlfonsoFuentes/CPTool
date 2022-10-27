namespace CPTool.Application.Features.MWOItemFeatures.CreateEdit
{
    public class EditMWOItemCurrencyValue : EditCommand, IRequest<Result<int>>
    {
        public int? PurchaseOrderId { get; set; }
        public int? MWOItemId => MWOItem?.Id == 0 ? null : MWOItem?.Id;
        public EditMWOItem? MWOItem { get; set; }
        public Currency Currency { get; set; } = Currency.COP;
        public double PrizeCurrency { get; set; }

        public double PrizeUSD
        {
            get => Currency == Currency.USD ? PrizeCurrency :
                Currency == Currency.COP ? Math.Round(PrizeCurrency / USDCOP, 2) : Math.Round(PrizeCurrency / USDEUR, 2);

        }
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }
        public double Tax { get; set; } = 0.19;
        public double PrizeCurrencyTax => Tax * PrizeCurrency;

        public double TotalPrizeCurrency => PrizeCurrency + PrizeCurrencyTax;
        public double ValueExchangeRate => Currency == Currency.EUR ? Currency == Currency.USD ? 1 : USDEUR : USDCOP;



    }
}
