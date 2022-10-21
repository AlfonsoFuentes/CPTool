namespace CPTool.Domain.Entities
{
    public class PurchaseOrderMWOItem  : BaseDomainModel
    {
        public int? PurchaseOrderId { get; set; }

        public PurchaseOrder? PurchaseOrder { get; set; }

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
