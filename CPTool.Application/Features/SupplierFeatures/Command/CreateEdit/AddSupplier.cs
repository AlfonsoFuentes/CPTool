

using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;
using CPTool.Application.Features.VendorCodeFeatures.CreateEdit;

namespace CPTool.Application.Features.SupplierFeatures.CreateEdit
{
    public class AddSupplier : AddCommand
    {

        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";


        public string Email { get; set; } = "";
        public string ContactPerson { get; set; } = "";

      
        public int? TaxCodeLPId { get; set; }
        public string? VendorCode { get; set; } = "";
        public int? TaxCodeLDId { get; set; }

    }
}
