﻿using CPTool.Domain.Enums;

namespace CPTool.Domain.Entities
{
    public class DownPayment  : AuditableEntity
    {
        [ForeignKey("DownpaymentId")]
        public ICollection<Taks> Taks { get; set; } = null!;
        public int? PurchaseOrderId { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? ManagerEmail { get; set; }
        public string? CBSRequesText { get; set; }
        public string? CBSRequesNo { get; set; }
        public string? ProformaInvoice { get; set; }
        public DownpaymentStatus DownpaymentStatus { get; set; }
        public string? Payterms { get; set; }
        public DateTime? DownPaymentDueDate { get; set; }
        public DateTime? DeliveryDueDate { get; set; }
        public DateTime? RealDate { get; set; }
        public double Percentage { get; set; }
        public double DownPaymentAmount { get; set; }
        public string? DownpaymentDescrption { get; set; }
        public string? Incotherm { get; set; }
        public DateTime? ApprovedDate { get; set; }
       
        public string? DownpaymentName { get; set; }

    }
}
