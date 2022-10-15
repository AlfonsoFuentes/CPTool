

using CPTool.Application.Contracts.Persistence;
using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.BrandSupplierFeatures.CreateEdit
{
    public enum InletBy
    {
        None,
        Brand,
        Supplier
    }
    public class AddBrandSupplier : AddCommand, IRequest<Result<int>>
    {

        public InletBy InletBy { get; set; } = InletBy.None;
        public int? BrandId => BrandCommand?.Id != 0 ? null : BrandCommand.Id;
        public EditBrand? BrandCommand { get; set; }

        public int? SupplierId => SupplierCommand?.Id != 0 ? null : SupplierCommand.Id;
        public EditSupplier? SupplierCommand { get; set; } 
        

    }

}
