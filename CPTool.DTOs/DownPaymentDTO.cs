using System.Globalization;

namespace CPTool.DTOS
{
    public class DownPaymentDTO : AuditableEntityDTO, IMapFrom<DownPayment>
    {
       
        public PurchaseOrderDTO? PurchaseOrderDTO { get; set; } = new();
        public string? ManagerEmail { get; set; } = "gabriel_perez@colpal.com";

        public string? CBSRequesText { get; set; }
        public string? CBSRequesNo { get; set; }
        public string? ProformaInvoice { get; set; }
        public DownpaymentStatus DownpaymentStatus { get; set; } = DownpaymentStatus.Draft;
        public string? Payterms { get; set; }

        public DateTime? RequestDate { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedDate { get; set; }
        public DateTime? DownPaymentDueDate { get; set; }
        public DateTime? DeliveryDueDate { get; set; }
        public DateTime? RealDate { get; set; }
        public double Percentage { get; set; }
        public double DownPaymentAmount => PurchaseOrderDTO!.PrizeCurrency * Percentage / 100;
        public string? DownpaymentDescrption { get; set; }
        public string? Incotherm { get; set; }

        public string? MWOName => PurchaseOrderDTO?.MWOItemDTO?.MWODTO?.CECName;
        public List<String> DownpaymentHistory = new();
        public string ButtonName = "";
        public void SetButtonNameHistory()
        {
            DownpaymentHistory = new();
            CultureInfo _en = CultureInfo.GetCultureInfo("en-US");
            DownpaymentHistory.Add($"MWO: {PurchaseOrderDTO?.MWOItemDTO?.MWODTO?.CECName}");


            if (DownpaymentStatus == DownpaymentStatus.Created)
            {
                DownpaymentHistory.Add($"PO: {PurchaseOrderDTO?.PONumber}");
                DownpaymentHistory.Add($"Downpayment created {RequestDate?.ToString("d", _en)}");
                ButtonName = "Approve";
            }
            else if (DownpaymentStatus == DownpaymentStatus.Approved)
            {
                DownpaymentHistory.Add($"PO: {PurchaseOrderDTO?.PONumber}");
                DownpaymentHistory.Add($"Downpayment created {RequestDate?.ToString("d", _en)}");
                DownpaymentHistory.Add($"Downpayment approved {ApprovedDate?.ToString("d", _en)}");
                ButtonName = "Pay";

            }
            else if (DownpaymentStatus == DownpaymentStatus.Paid)
            {
                DownpaymentHistory.Add($"PO: {PurchaseOrderDTO?.PONumber}");
                DownpaymentHistory.Add($"Downpayment created {RequestDate?.ToString("d", _en)}");
                DownpaymentHistory.Add($"Downpayment approved {ApprovedDate?.ToString("d", _en)}");
                DownpaymentHistory.Add($"Downpayment paid {RealDate?.ToString("d", _en)}");
                ButtonName = "Close";

            }


        }
        public void ChangeStatusDP()
        {
            if (DownpaymentStatus == DownpaymentStatus.Draft)
            {
                DownpaymentStatus = DownpaymentStatus.Created;
                RequestDate = DateTime.UtcNow;


            }
            else if (DownpaymentStatus == DownpaymentStatus.Created)
            {
                DownpaymentStatus = DownpaymentStatus.Approved;
                ApprovedDate = DateTime.UtcNow;


            }
            else if (DownpaymentStatus == DownpaymentStatus.Approved)
            {
                DownpaymentStatus = DownpaymentStatus.Paid;
                RealDate = DateTime.UtcNow;

            }

        }
    }


}
