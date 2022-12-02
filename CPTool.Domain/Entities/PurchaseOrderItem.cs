namespace CPTool.Domain.Entities
{
    public class PurchaseOrderItem : BaseDomainModel
    {
        public int? PurchaseOrderId { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        public int? MWOItemId { get; set; }
        public MWOItem? MWOItem { get; set; }
      
        public double PrizeCurrency { get; set; }
        public double PrizeUSD { get; set; }
       
        public double Tax { get; set; }
        public double PrizeCurrencyTax { get; set; }
    }




}
