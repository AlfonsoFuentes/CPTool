using CPTool.ApplicationCQRS.Features.PurchaseOrderItems.Commands.CreateUpdate;
using CPTool.Domain.Enums;

namespace CPTool.ApplicationCQRS.Features.PurchaseOrders.Commands.CreateUpdate
{
    public class AddPurchaseOrder
    {

       public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? pBrandId { get; set; }
        public int? pSupplierId { get; set; }
        public List<AddPurchaseOrderItem> PurchaseOrderItems { get; set; } = new();
        public int? MWOId { get; set; }
        public string PurchaseRequisition { get; set; } = "";

        public DateTime POCreatedDate { get; set; }
        public DateTime POReceivedDate { get; set; }
        public DateTime POInstalledDate { get; set; }
        public DateTime POEstimatedDate { get; set; }
        public DateTime POOrderingdDate { get; set; }
        public string PONumber { get; set; } = "";
        public string SPL { get; set; } = "";
        public string TaxCode { get; set; } = "";

        public PurchaseOrderApprovalStatus PurchaseOrderStatus { get; set; }
        public Currency Currency { get; set; } = Currency.COP;
        public DateTime CurrencyDate { get; set; }
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }
       

    }
    public class UpdatePurchaseOrder
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? pBrandId { get; set; }
        public int? pSupplierId { get; set; }
         public int? MWOId { get; set; }
        public string PurchaseRequisition { get; set; } = "";

        public DateTime POCreatedDate { get; set; }
        public DateTime POReceivedDate { get; set; }
        public DateTime POInstalledDate { get; set; }
        public DateTime POEstimatedDate { get; set; }
        public DateTime POOrderingdDate { get; set; }
        public string PONumber { get; set; } = "";
        public string SPL { get; set; } = "";
        public string TaxCode { get; set; } = "";

        public PurchaseOrderApprovalStatus PurchaseOrderStatus { get; set; }
        public Currency Currency { get; set; } = Currency.COP;
        public DateTime CurrencyDate { get; set; }
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }


    }

}
