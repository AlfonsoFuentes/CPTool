using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using System.Reflection;

namespace CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit
{
    public class EditPurchaseOrder : EditCommand, IRequest<Result<int>>
    {
        public string TaxCode => MWOItem==null?"":
            MWOItem.ChapterId == 1 ? pSupplier!.TaxCodeLP!.Name : pSupplier!.TaxCodeLD!.Name;
        public string SPL => MWOItem.ChapterId! == 1 ? "43000" : "15000";

        public string CostCenter => MWOItem!.ChapterId! == 1 ? MWOItem!.AlterationItem!.CostCenter! : "";
        public EditMWOItem MWOItem { get; set; } = new();
        public string PurchaseRequisition { get; set; } = "";

        public DateTime POCreatedDate { get; set; }
        public DateTime POReceivedDate { get; set; }
        public DateTime POInstalledDate { get; set; }
        public DateTime POEstimatedDate { get; set; }
        public DateTime POOrderingdDate { get; set; }
        public string PONumber { get; set; } = "";

        List<EditMWOItem> MWOItems => PurchaseOrderMWOItems!.Count == 0 ? new() :
            PurchaseOrderMWOItems!.Where(x => x.PurchaseOrderId! == Id).Select(x => x.MWOItem!).ToList();
        public double Value => MWOItems.Count==0?0: MWOItems.Select(x => x.MWOItemCurrencyValues.Where(x => x.PurchaseOrderId == Id).ToList()).Sum(y => y.Sum(z => z.PrizeCurrency));
        public PurchaseOrderStatus PurchaseOrderStatus { get; set; } = PurchaseOrderStatus.Draft;
        public double ValueUSD => MWOItems.Count == 0 ? 0 : MWOItems.Select(x => x.MWOItemCurrencyValues.Where(x => x.PurchaseOrderId == Id).ToList()).Sum(y => y.Sum(z => z.PrizeUSD));

        public Currency Currency => MWOItems.Count == 0 ? Currency.None : MWOItems!.FirstOrDefault().MWOItemCurrencyValues!.FirstOrDefault(x => x.PurchaseOrderId == Id).Currency;
        public int? MWOId => MWO == null ? null : MWO?.Id;
        public EditMWO? MWO { get; set; }

        public int? pBrandId => pBrand?.Id == 0 ? null : pBrand?.Id;
        public EditBrand? pBrand { get; set; } = new();
        public int? pSupplierId => pSupplier?.Id == 0 ? null : pSupplier?.Id;
        public EditSupplier? pSupplier { get; set; } = new();

        public List<EditPurchaseOrderMWOItem>? PurchaseOrderMWOItems { get; set; } = new();

        public List<EditDownPayment>? DownPayments { get; set; }

    }
}
