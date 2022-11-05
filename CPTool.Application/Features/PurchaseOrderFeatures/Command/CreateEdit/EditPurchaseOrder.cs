using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Application.Features.TaksFeatures.CreateEdit;
using System.Reflection;

namespace CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit
{
    public class EditPurchaseOrder : EditCommand, IRequest<Result<int>>
    {
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

        List<EditMWOItem> MWOItems => PurchaseOrderMWOItems!.Count == 0 ? new() :
            PurchaseOrderMWOItems!.Where(x => x.PurchaseOrderId! == Id).Select(x => x.MWOItem!).ToList();
        public double Value => MWOItems.Count==0?0: MWOItems.Select(x => x.MWOItemCurrencyValues.Where(x => x.PurchaseOrderId == Id).ToList()).Sum(y => y.Sum(z => z.PrizeCurrency));
        public PurchaseOrderStatus PurchaseOrderStatus { get; set; } = PurchaseOrderStatus.Draft;
        public double ValueUSD => MWOItems.Count == 0 ? 0 : MWOItems.Select(x => x.MWOItemCurrencyValues.Where(x => x.PurchaseOrderId == Id).ToList()).Sum(y => y.Sum(z => z.PrizeUSD));
        public double PrizeCurrency => MWOItems.Count == 0 ? 0 : MWOItems.Select(x => x.MWOItemCurrencyValues.Where(x => x.PurchaseOrderId == Id).ToList()).Sum(y => y.Sum(z => z.PrizeCurrency));
        public double PrizeCurrencyTax => MWOItems.Count == 0 ? 0 : MWOItems.Select(x => x.MWOItemCurrencyValues.Where(x => x.PurchaseOrderId == Id).ToList()).Sum(y => y.Sum(z => z.PrizeCurrencyTax));
        public double TotalPrizeCurrency => MWOItems.Count == 0 ? 0 : MWOItems.Select(x => x.MWOItemCurrencyValues.Where(x => x.PurchaseOrderId == Id).ToList()).Sum(y => y.Sum(z => z.TotalPrizeCurrency));
        public Currency Currency => MWOItems!.Count == 0 ? Currency.None : MWOItems!.FirstOrDefault()!.MWOItemCurrencyValues!.FirstOrDefault(x => x.PurchaseOrderId == Id)!.Currency;
        public int? MWOId => MWO == null ? null : MWO?.Id;
        public EditMWO MWO { get; set; } = null!;

        public int? pBrandId => pBrand?.Id == 0 ? null : pBrand?.Id;
        public EditBrand? pBrand { get; set; } = new();
        public int? pSupplierId => pSupplier?.Id == 0 ? null : pSupplier?.Id;
        public EditSupplier? pSupplier { get; set; } = new();

        public List<EditPurchaseOrderMWOItem>? PurchaseOrderMWOItems { get; set; } = new();

        public List<EditDownPayment>? DownPayments { get; set; }
        public List<EditTaks>? Taks { get; set; }

        public EditTaks? EditTaks => Taks!.Count==0 ? null : Taks.FirstOrDefault();  

    }
}
