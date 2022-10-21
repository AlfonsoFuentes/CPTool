using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.MWOFeatures.CreateEdit;
using CPTool.Application.Features.MWOItemFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit
{
    public class EditPurchaseOrder : EditCommand, IRequest<Result<int>>
    {

        public string PurchaseRequisition { get; set; } = "";

        public DateTime POCreatedDate { get; set; }
        public DateTime POReceivedDate { get; set; }
        public DateTime POInstalledDate { get; set; }
        public DateTime POEstimatedDate { get; set; }
        public DateTime POOrderingdDate { get; set; }
        public string PONumber { get; set; } = "";
        public string SPL { get; set; } = "";
        public string TaxCode { get; set; } = "";

        public Currency Currency { get; set; } = Currency.COP;
        public double PrizeCurrency { get; set; }
        public double PrizeUSD { get; set; }
        public double USDCOP { get; set; }
        public double USDEUR { get; set; }

        public double Tax { get; set; }
        public double PrizeCurrencyTax { get; set; }
        public double TotalPrizeCurrency { get; set; }
        public int? MWOItemId => MWOItem?.Id==0?null: MWOItem?.Id;
        public EditMWOItem? MWOItem { get; set; }

        public int? pBrandId => pBrand?.Id == 0 ? null : pBrand?.Id;
        public EditBrand? pBrand { get; set; }
        public int? pSupplierId => pSupplier?.Id == 0 ? null : pSupplier?.Id;
        public EditSupplier? pSupplier { get; set; }

    }

}
