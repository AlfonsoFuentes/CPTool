﻿

using CPTool.Domain.Enums;

namespace CPTool.Domain.Entities
{
    public class PurchaseOrder : AuditableEntity
    {

        public int? MWOId { get; set; }
        public MWO? MWO { get; set; } = null!;

        [ForeignKey("PurchaseOrderId")]
        public ICollection<DownPayment>? DownPayments { get; set; }
        [ForeignKey("PurchaseOrderId")]
        public ICollection<Taks> Taks { get; set; } = null!;
        public string QuoteNo { get; set; } = "";
        public ICollection<PurchaseOrderItem>? PurchaseOrderItems { get; set; }
        public Currency Currency { get; set; }
        public PurchaseOrderApprovalStatus PurchaseOrderStatus { get; set; }
        public int? pBrandId { get; set; }
        public Brand? pBrand { get; set; }
        public int? pSupplierId { get; set; }
        public Supplier? pSupplier { get; set; }


        public string PurchaseRequisition { get; set; } = "";

        public DateTime POCreatedDate { get; set; }
        public DateTime POReceivedDate { get; set; }
        public DateTime POInstalledDate { get; set; }
        public DateTime POEstimatedDate { get; set; }
        public DateTime POOrderingdDate { get; set; }
        public string PONumber { get; set; } = "";
        public string SPL { get; set; } = "";
        public string TaxCode { get; set; } = "";
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }
        public DateTime CurrencyDate { get; set; }
        public string CostCenter { get; set; } = "";
    }
}
