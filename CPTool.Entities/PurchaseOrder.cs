

using CPTool.Interfaces;

namespace CPTool.Entities
{
    public class PurchaseOrder : AuditableEntity
    {


        public ICollection<DownPayment>? DownPayments { get; set; }
        public  ICollection<PurchaseOrderMWOItem>? PurchaseOrderMWOItems { get; set; }

        public PurchaseOrderStatus PurchaseOrderStatus { get; set; }

       //public Brand? Brand { get; set; }
        public Supplier? Supplier { get; set; }
        public int? SupplierId { get; set; }
        //public int? BrandId { get; set; }
        public string PurchaseRequisition { get; set; } = "";

        public DateTime POCreatedDate { get; set; }
        public DateTime POReceivedDate { get; set; }
        public DateTime POInstalledDate { get; set; }
        public DateTime POEstimatedDate { get; set; }
        public DateTime POOrderingdDate { get; set; }
        public string PONumber { get; set; } = "";
        public string SPL { get; set; } = "";
        public string TaxCode { get; set; } = "";

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
