namespace CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate
{
    public class AddPurchaseOrderItem
    {

       public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? PurchaseOrderId { get; set; }
        public int? MWOItemId { get; set; }

        public double PrizeCurrency { get; set; }

        public double PrizeUSD { get; set; }

        public double Tax { get; set; }
        public double PrizeCurrencyTax { get; set; }

        public double TotalPrizeCurrency { get; set; }
        public double ValueExchangeRate { get; set; }
    }

}
