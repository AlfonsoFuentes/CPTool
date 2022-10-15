using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;
using CPTool.Application.Features.VendorCodeFeatures.CreateEdit;

namespace CPTool.Application.Features.SupplierFeatures.CreateEdit
{
    public class EditSupplier : EditCommand, IRequest<Result<int>>
    {

        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";


        public string Email { get; set; } = "";
        public string ContactPerson { get; set; } = "";

        public List<EditBrandSupplier> BrandSuppliers { get; set; } = new();
        //public int? TaxCodeLPId => TaxCodeLP.Id == 0 ? null : TaxCodeLP.Id;
        public EditTaxCodeLP TaxCodeLP { get; set; } = new();
        //public int? VendorCodeId => VendorCode.Id == 0 ? null : VendorCode.Id;
        public EditVendorCode VendorCode { get; set; } = new();
        //public int? TaxCodeLDId => TaxCodeLD.Id == 0 ? null : TaxCodeLD.Id;
        public EditTaxCodeLD TaxCodeLD { get; set; } = new();

    }
}
