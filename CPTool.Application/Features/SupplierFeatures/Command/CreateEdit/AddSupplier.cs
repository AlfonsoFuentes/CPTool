

using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;
using CPTool.Application.Features.VendorCodeFeatures.CreateEdit;

namespace CPTool.Application.Features.SupplierFeatures.CreateEdit
{
    public class AddSupplier : AddCommand, IRequest<Result<int>>
    {

        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";


        public string Email { get; set; } = "";
        public string ContactPerson { get; set; } = "";

      
        public int? TaxCodeLPId => TaxCodeLPCommand?.Id == 0 ? null : TaxCodeLPCommand?.Id;
        public EditTaxCodeLP? TaxCodeLPCommand { get; set; } = new();
        public int? VendorCodeId => VendorCodeCommand?.Id == 0 ? null : VendorCodeCommand?.Id;
        public EditVendorCode? VendorCodeCommand { get; set; } = new();
        public int? TaxCodeLDId => TaxCodeLDCommand?.Id==0?null: TaxCodeLDCommand?.Id;
        public EditTaxCodeLD? TaxCodeLDCommand { get; set; } = new();
    
    }
}
