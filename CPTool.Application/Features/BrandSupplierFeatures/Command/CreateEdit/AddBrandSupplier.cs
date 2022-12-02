


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
    public class AddBrandSupplier : AddCommand
    {

        public InletBy InletBy { get; set; } = InletBy.None;
        public int BrandId { get; set; }
        public int SupplierId { get; set; }

       

    }

}
