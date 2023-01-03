using CPTool.ApplicationCQRS.Features.Brands.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.DownPayments.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Suppliers.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;
using CPTool.ApplicationCQRS.Responses;
using CPTool.Domain.Enums;
using MediatR;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate
{
    public class CommandPurchaseOrder : CommandBase, IRequest<PurchaseOrderCommandResponse>
    {


        public DateTime? CurrencyDate { get; set; } = DateTime.UtcNow;
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }
        public string TaxCode { get; set; } = "";
        public string SPL { get; set; } = "";
        public string VendorCode => pSupplier == null ? "" : pSupplier!.VendorCode!;
        public string CostCenter { get; set; } = "";




        public string PurchaseRequisition { get; set; } = "";

        public DateTime POCreatedDate { get; set; } = DateTime.Now;
        public DateTime POReceivedDate { get; set; }
        public DateTime POInstalledDate { get; set; }
        public DateTime? POEstimatedDate { get; set; }
        public DateTime POOrderingdDate { get; set; }

        public string PONumber { get; set; } = "";

        public string PurchaseOrderApprovalStatusName => PurchaseOrderStatus.ToString();
        public PurchaseOrderApprovalStatus PurchaseOrderStatus { get; set; } = PurchaseOrderApprovalStatus.Draft;

        public string PrizeUSDValue => String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", PrizeUSD);
        public double PrizeUSD => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(x => x.PrizeUSD);
        public string PrizeCurrencyValue => String.Format(new System.Globalization.CultureInfo("en-US"), "{0:C}", PrizeCurrency);
        public double PrizeCurrency => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(x => x.PrizeCurrency);
        public double PrizeCurrencyTax => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(x => x.PrizeCurrencyTax);

        public double TotalPrizeCurrency => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(x => x.TotalPrizeCurrency);

        public string CurrencyName => Currency.ToString();
        public Currency Currency { get; set; } = Currency.COP;
        public int? MWOId => MWO == null ? null : MWO?.Id;
        public CommandMWO MWO { get; set; } = null!;
        public string MWOName => MWO!.Name;
        public string MWOCECName => MWO!.CECName;
       
        public int? pBrandId => pBrand?.Id == 0 ? null : pBrand?.Id;
        public CommandBrand? pBrand { get; set; } = new();

        public string BrandName => pBrand!.Name;
        public int? pSupplierId => pSupplier?.Id == 0 ? null : pSupplier?.Id;
        public CommandSupplier? pSupplier { get; set; } = new();


        public string SupplierName => pSupplier!.Name;

        public List<CommandPurchaseOrderItem> PurchaseOrderItems { get; set; } = new();
        public List<CommandDownPayment>? DownPayments { get; set; }
        public List<CommandTaks>? Taks { get; set; }

        public CommandTaks? CommandTaks => Taks!.Count == 0 ? null : Taks.FirstOrDefault();

        public double ActualValue => (PurchaseOrderItems.Count == 0) ? 0 : 
            StatusPurchaseOrder == StatusPurchaseOrder.Actual ? PurchaseOrderItems.Where(x=>x!.MWOItem!.ChapterId!=1).Sum(x => x.PrizeUSD) : 0;
        public double CommitmentValue => (PurchaseOrderItems.Count == 0) ? 0 : 
            StatusPurchaseOrder == StatusPurchaseOrder.Commitment ? PurchaseOrderItems.Where(x => x!.MWOItem!.ChapterId != 1).Sum(x => x.PrizeUSD) : 0;

        public double ActualValueExpenses => (PurchaseOrderItems.Count == 0) ? 0 :
           StatusPurchaseOrder == StatusPurchaseOrder.Actual ? PurchaseOrderItems.Where(x => x!.MWOItem!.ChapterId == 1).Sum(x => x.PrizeUSD) : 0;
        public double CommitmentValueExpenses => (PurchaseOrderItems.Count == 0) ? 0 :
            StatusPurchaseOrder == StatusPurchaseOrder.Commitment ? PurchaseOrderItems.Where(x => x!.MWOItem!.ChapterId == 1).Sum(x => x.PrizeUSD) : 0;
        public StatusPurchaseOrder StatusPurchaseOrder => GetStatusPurchaseOrder();
        StatusPurchaseOrder GetStatusPurchaseOrder()
        {
            if (pBrand != null && pBrand!.BrandType == BrandType.Brand &&
                (PurchaseOrderStatus == PurchaseOrderApprovalStatus.Received || PurchaseOrderStatus == PurchaseOrderApprovalStatus.Closed))
            {
                return StatusPurchaseOrder.Actual;
            }
            else if (pBrand != null && pBrand!.BrandType == BrandType.Service &&
                (PurchaseOrderStatus == PurchaseOrderApprovalStatus.Installed || PurchaseOrderStatus == PurchaseOrderApprovalStatus.Closed))
            {
                return StatusPurchaseOrder.Actual;
            }
            return StatusPurchaseOrder.Commitment;
        }






    }
    public enum StatusPurchaseOrder
    {
        Actual,
        Commitment
    }
}
