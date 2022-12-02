namespace CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit
{
    public class AddPurchaseOrderItem : AddCommand
    {
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
