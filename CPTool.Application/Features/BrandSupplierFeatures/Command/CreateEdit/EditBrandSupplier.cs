using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;
using CPTool.Domain.Entities;

namespace CPTool.Application.Features.BrandSupplierFeatures.CreateEdit
{
    public class EditBrandSupplier : EditCommand, IRequest<Result<int>>
    {
        public int SupplierOriginalId { get; set; }
        public int BrandOriginalId { get; set; }
        public int BrandId => Brand == null ? 0 : Brand!.Id;
        public EditBrand? Brand { get; set; } = new();

        public int SupplierId => Supplier == null ? 0 : Supplier!.Id;
        public EditSupplier? Supplier { get; set; } = new();

       
        public void SetOriginalId(EditBrand brand, EditSupplier supplier)
        {
            Supplier = supplier;
            Brand = brand;
            BrandOriginalId = Brand.Id;
            SupplierOriginalId = Supplier.Id;
        }
    }

}
