using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.BrandSupplierFeatures.CreateEdit
{
    public class EditBrandSupplier : EditCommand, IRequest<Result<int>>
    {

        public InletBy InletBy { get; set; } = InletBy.None;
        //public int? BrandId => BrandCommand?.Id != 0 ? null : BrandCommand.Id;
        public EditBrand? Brand { get; set; }

        //public int? SupplierId => SupplierCommand?.Id != 0 ? null : SupplierCommand.Id;
        public EditSupplier? Supplier { get; set; }

    }

}
