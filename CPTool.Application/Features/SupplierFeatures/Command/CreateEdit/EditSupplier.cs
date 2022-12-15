
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;

using CPTool.Application.Features.TaxCodeLDFeatures.CreateEdit;
using CPTool.Application.Features.TaxCodeLPFeatures.CreateEdit;


namespace CPTool.Application.Features.SupplierFeatures.CreateEdit
{
    public class EditSupplier : EditCommand, IRequest<Result<int>>
    {
     

        public int SupplierOriginalId { get; set; }
        public List<EditBrandSupplier>? BrandSuppliers { get; set; } = new();
        [Report]
        public string Address { get; set; } = "";
        [Report]
        public string Phone { get; set; } = "";

        [Report]
        public string Email { get; set; } = "";
        [Report]
        public string ContactPerson { get; set; } = "";

      
        public int? TaxCodeLPId => TaxCodeLP?.Id == 0 ? null : TaxCodeLP?.Id;
        public EditTaxCodeLP? TaxCodeLP { get; set; }
        [Report]
        public string TaxCodeLPName => TaxCodeLP == null ? "" : TaxCodeLP!.Name;
        [Report]
        public string? VendorCode { get; set; } = "";
        public int? TaxCodeLDId => TaxCodeLD?.Id == 0 ? null : TaxCodeLD?.Id;
        public EditTaxCodeLD? TaxCodeLD { get; set; }
        [Report]
        public string TaxCodeLDName => TaxCodeLD==null?"": TaxCodeLD!.Name;
    }
}
