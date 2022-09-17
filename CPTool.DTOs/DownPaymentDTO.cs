namespace CPTool.DTOS
{
    public class DownPaymentDTO:AuditableEntityDTO
    {
        public int? PurchaseOrderId => PurchaseOrderDTO?.Id;
        public PurchaseOrderDTO? PurchaseOrderDTO { get; set; } = new();
        public string? ManagerEmail { get; set; } = "gabriel_perez@colpal.com";
        public DateTime? RequestDate { get; set; } = DateTime.UtcNow;
        public string? CBSRequesText { get; set; }
        public string? CBSRequesNo { get; set; }
        public string? ProformaInvoice { get; set; }
        public DownpaymentStatus DownpaymentStatus { get; set; }
        public string? Payterms { get; set; }
        public DateTime? DownPaymentDueDate { get; set; }
        public DateTime? DeliveryDueDate { get; set; }
        public DateTime? RealDate { get; set; }
        public double Percentage { get; set; }
        public double DownPaymentAmount => PurchaseOrderDTO!.PrizeCurrency * Percentage / 100;
        public string? DownpaymentDescrption { get; set; }
        public string? Incotherm { get; set; }

        public string? MWOName => PurchaseOrderDTO?.MWOItemDTO?.MWODTO?.CECName;
    }
    

}
