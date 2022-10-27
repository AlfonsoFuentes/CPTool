namespace CPTool.Application.Features.MWOItemFeatures.CreateEdit
{
    public class AddMWOItemCurrencyValue : AddCommand
    {
        public int? PurchaseOrderId { get; set; }
        public int? MWOItemId { get; set; }
        public Currency Currency { get; set; }
        public double PrizeCurrency { get; set; }

        public double PrizeUSD { get; set; }
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }
        public double Tax { get; set; } 
        public double PrizeCurrencyTax { get; set; }

        public double TotalPrizeCurrency { get; set; }
        public double ValueExchangeRate { get; set; }



    }
}
