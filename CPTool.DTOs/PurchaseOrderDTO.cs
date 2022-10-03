

using System.Globalization;

namespace CPTool.DTOS
{
    public class PurchaseOrderDTO : AuditableEntityDTO, IMapFrom<PurchaseOrder>
    {
        public List<DownPaymentDTO>? DownPaymentsDTO { get; set; }
        public List<PurchaseOrderMWOItemDTO>? PurchaseOrderMWOItemsDTO { get; set; } = new();

        MWOItemDTO? _MWOItemDTO;
        public MWOItemDTO? MWOItemDTO
        {
            get
            {
                return PurchaseOrderMWOItemsDTO?.Count == 0 ? _MWOItemDTO : PurchaseOrderMWOItemsDTO?.FirstOrDefault()?.MWOItemDTO;
            }
            set
            {
                _MWOItemDTO = value;
            }
        }
        public PurchaseOrderStatus PurchaseOrderStatus { get; set; } = PurchaseOrderStatus.Draft;

        public BrandDTO? BrandDTO { get; set; } = new();
        public SupplierDTO? SupplierDTO { get; set; } = new();
        
        public string PurchaseRequisition { get; set; } = "";
        public DateTime? POOrderingdDate { get; set; }
        public DateTime? POCreatedDate { get; set; }
        public DateTime? POReceivedDate { get; set; }
        public DateTime? POInstalledDate { get; set; }
        public DateTime? POEstimatedDate { get; set; }
        public DateTime? LastEvenDate => 
            PurchaseOrderStatus == PurchaseOrderStatus.Ordering ? POOrderingdDate :
            PurchaseOrderStatus == PurchaseOrderStatus.Created ? POCreatedDate : 
            PurchaseOrderStatus== PurchaseOrderStatus.Received ? POReceivedDate : POInstalledDate;
        public string PONumber { get; set; } = "";
        public string SPL => MWOItemDTO?.ChapterDTO?.Id == 1 ? "SPL Alteration" : "SPL No Alteration";
        public string TaxCode => MWOItemDTO?.ChapterDTO?.Id == 1 ? SupplierDTO?.TaxCodeLPDTO?.Name! : SupplierDTO?.TaxCodeLDDTO?.Name!;
        public string CostCenter => MWOItemDTO?.ChapterDTO?.Id == 1 ? MWOItemDTO?.AlterationItemDTO?.CostCenter! : "";
        public Currency Currency { get; set; } = Currency.COP;
        public double PrizeCurrency { get; set; }


        public double Tax { get; set; } = 0.19;
        public double PrizeCurrencyTax => Tax * PrizeCurrency;
        public double TotalPrizeCurrency => PrizeCurrency + PrizeCurrencyTax;
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }
        public double ValueExchangeRate => Currency == Currency.EUR ? Currency == Currency.USD ? 1 : USDEUR : USDCOP;
        public double PrizeUSD
        {
            get => Currency == Currency.USD ? PrizeCurrency :
                Currency == Currency.COP ? Math.Round(PrizeCurrency / USDCOP, 2) : Math.Round(PrizeCurrency / USDEUR, 2);

        }
        public string ButtonName = "";
        public List<String> PurchaseOrderHistory = new();
        public void SetButtonNameHistory()
        {
            PurchaseOrderHistory = new();
            CultureInfo _en = CultureInfo.GetCultureInfo("en-US");
            PurchaseOrderHistory.Add($"MWO: {MWOItemDTO?.MWODTO?.CECName}");
            if (MWOItemDTO?.ChapterDTO?.Id == 1)
            {
                PurchaseOrderHistory.Add($"Cost Center: {MWOItemDTO?.AlterationItemDTO?.CostCenter}");
            }


            if (PurchaseOrderStatus == PurchaseOrderStatus.Draft)
            {
                PurchaseOrderHistory.Add("Purchase order in draft");
                ButtonName = "Create";
            }

            else if (PurchaseOrderStatus == PurchaseOrderStatus.Ordering)
            {
                PurchaseOrderHistory.Add("PO Ordering");
                PurchaseOrderHistory.Add($"PR: {PurchaseRequisition}");
                PurchaseOrderHistory.Add($"Created date: {POOrderingdDate?.ToString("d",_en)}");
                PurchaseOrderHistory.Add($"Pending to submit:");
                PurchaseOrderHistory.Add($"PO Number");
                PurchaseOrderHistory.Add($"Estimated receive date");
                ButtonName = "Order";
            }

            else if (PurchaseOrderStatus == PurchaseOrderStatus.Created)
            {
                PurchaseOrderHistory.Add("PO Ordered");
                PurchaseOrderHistory.Add($"PR: {PurchaseRequisition}");
                PurchaseOrderHistory.Add($"PO: {PONumber}");
                PurchaseOrderHistory.Add($"Created date: {POOrderingdDate?.ToString("d",_en)}");
                PurchaseOrderHistory.Add($"Ordered date: {POCreatedDate?.ToString("d",_en)}");
                PurchaseOrderHistory.Add($"Estimated date: {POEstimatedDate?.ToString("d",_en)}");

                ButtonName = "Receive";
            }

            else if (PurchaseOrderStatus == PurchaseOrderStatus.Received)
            {
                PurchaseOrderHistory.Add("PO Ordered");
                PurchaseOrderHistory.Add($"PR: {PurchaseRequisition}");
                PurchaseOrderHistory.Add($"PO: {PONumber}");
                PurchaseOrderHistory.Add($"Created date: {POOrderingdDate?.ToString("d",_en)}");
                PurchaseOrderHistory.Add($"Ordered date: {POCreatedDate?.ToString("d",_en)}");
                PurchaseOrderHistory.Add($"Estimated date: {POEstimatedDate?.ToString("d",_en)}");
                PurchaseOrderHistory.Add($"Received date date: {POReceivedDate?.ToString("d",_en)}");
                ButtonName = "Install";
            }
            else if (PurchaseOrderStatus == PurchaseOrderStatus.Installed)
            {
                PurchaseOrderHistory.Add("PO Ordered");
                PurchaseOrderHistory.Add($"PR: {PurchaseRequisition}");
                PurchaseOrderHistory.Add($"PO: {PONumber}");
                PurchaseOrderHistory.Add($"Created date: {POOrderingdDate?.ToString("d",_en)}");
                PurchaseOrderHistory.Add($"Ordered date: {POCreatedDate?.ToString("d",_en)}");
                PurchaseOrderHistory.Add($"Estimated date: {POEstimatedDate?.ToString("d",_en)}");
                PurchaseOrderHistory.Add($"Received date date: {POReceivedDate?.ToString("d",_en)}");
                PurchaseOrderHistory.Add($"Installed date date: {POInstalledDate?.ToString("d",_en)}");
                ButtonName = "Closed";
            }

        }
        public void ChangeStatusPO()
        {
            if (PurchaseOrderStatus == PurchaseOrderStatus.Draft)
            {
                PurchaseOrderStatus = PurchaseOrderStatus.Ordering;
                POOrderingdDate = DateTime.UtcNow;

            }

            else if (PurchaseOrderStatus == PurchaseOrderStatus.Ordering)
            {
                PurchaseOrderStatus = PurchaseOrderStatus.Created;
                POCreatedDate = DateTime.UtcNow;
            }

            else if (PurchaseOrderStatus == PurchaseOrderStatus.Created)
            {
                PurchaseOrderStatus = PurchaseOrderStatus.Received;
                POReceivedDate = DateTime.UtcNow;
            }

            else if (PurchaseOrderStatus == PurchaseOrderStatus.Received)
            {
                PurchaseOrderStatus = PurchaseOrderStatus.Installed;
                POInstalledDate = DateTime.UtcNow;
            }

        }

    }


}
