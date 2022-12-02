using CPTool.Application.Features.BrandFeatures;
using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetById;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;

using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;

using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using System.Reflection;

namespace CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit
{
    public class EditPurchaseOrder : EditCommand, IRequest<Result<int>>
    {
        public DateTime? CurrencyDate { get; set; }
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }
        public string TaxCode { get; set; } = "";
        public string SPL { get; set; } = "";
        public string VendorCode => pSupplier!.VendorCode!=null? pSupplier!.VendorCode!:"";
        public string CostCenter { get; set; } = "";

     
        public EditMWOItem? MWOItem { get; set; } 
        public string PurchaseRequisition { get; set; } = "";

        public DateTime POCreatedDate { get; set; } = DateTime.Now;
        public DateTime POReceivedDate { get; set; }
        public DateTime POInstalledDate { get; set; }
        public DateTime? POEstimatedDate { get; set; }
        public DateTime POOrderingdDate { get; set; }
        public string PONumber { get; set; } = "";

       
        public PurchaseOrderStatus PurchaseOrderStatus { get; set; } = PurchaseOrderStatus.Draft;
        public double PrizeUSD => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(x => x.PrizeUSD);
        public double PrizeCurrency => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(x => x.PrizeCurrency); 
        public double PrizeCurrencyTax => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(x => x.PrizeCurrencyTax); 
        public double TotalPrizeCurrency => PurchaseOrderItems.Count == 0 ? 0 : PurchaseOrderItems.Sum(x => x.TotalPrizeCurrency);
       
        public Currency Currency { get; set; } = Currency.COP;
        public int? MWOId => MWO == null ? null : MWO?.Id;
        public EditMWO MWO { get; set; } = null!;

        public EditPurchaseOrderItem PurchaseOrderItem { get; set; } = new();
        public int? pBrandId => pBrand?.Id == 0 ? null : pBrand?.Id;
        public EditBrand? pBrand { get; set; } = new();
        public int? pSupplierId => pSupplier?.Id == 0 ? null : pSupplier?.Id;
        public EditSupplier? pSupplier { get; set; } = new();

        //public List<EditPurchaseOrderMWOItem>? PurchaseOrderMWOItems { get; set; } = new();

        public List<EditPurchaseOrderItem> PurchaseOrderItems { get; set; } = new();
        public List<EditDownPayment>? DownPayments { get; set; }
        public List<EditTaks>? Taks { get; set; }

        public EditTaks? EditTaks => Taks!.Count==0 ? null : Taks.FirstOrDefault();  

    }
}
