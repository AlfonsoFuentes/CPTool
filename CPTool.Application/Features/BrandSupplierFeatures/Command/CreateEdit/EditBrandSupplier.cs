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

        public override void CreateMasterRelations<T1, T2>(T1 Master1, T2 Master2)
        {
            Brand = Master1 as EditBrand;
            Supplier = Master2 as EditSupplier;
        }
        public override void SetMaster<T1, T2>(T1 Master1, T2 Master2)
        {
            Brand = Master1 as EditBrand;
            var supplier = Master2 as EditSupplier;
           
            Supplier = Brand!.BrandSuppliers!.Count == 0 ? new() :
               Brand!.BrandSuppliers!.Any(x => x.SupplierId == supplier!.Id) ? supplier :
               Brand!.BrandSuppliers!.FirstOrDefault()!.Supplier;
            BrandOriginalId = Brand!.Id;
            SupplierOriginalId = Supplier!.Id;
        }
        public override void SetDetail<T1, T2>(T1 Master1, T2 Master2)
        {
            Supplier = Master1 as EditSupplier;
            var brand = Master2 as EditBrand;
            Brand = Supplier!.BrandSuppliers!.Count==0?new():
                Supplier!.BrandSuppliers!.Any(x => x.BrandId == brand!.Id) ? brand :
                Supplier!.BrandSuppliers!.FirstOrDefault()!.Brand;
            BrandOriginalId = Brand!.Id;
            SupplierOriginalId = Supplier.Id;

        }
        public void SetOriginalId(EditBrand brand, EditSupplier supplier)
        {
            Supplier = supplier;
            Brand = brand;
            BrandOriginalId = Brand.Id;
            SupplierOriginalId = Supplier.Id;
        }
    }

}
