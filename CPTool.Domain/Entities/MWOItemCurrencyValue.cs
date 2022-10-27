namespace CPTool.Domain.Entities
{
    public class MWOItemCurrencyValue : BaseDomainModel
    {
        public int? PurchaseOrderId { get; set; }
        public int? MWOItemId { get; set; }
        public MWOItem? MWOItem { get; set; }
        public Currency Currency { get; set; }
        public double PrizeCurrency { get; set; }
        public double PrizeUSD { get; set; }
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }
        public DateTime CurrencyDate { get; set; }

        public double Tax { get; set; }
        public double PrizeCurrencyTax { get; set; }
    }




}
