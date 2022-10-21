using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.SupplierFeatures.CreateEdit;

namespace CPTool.Application.Features.BrandSupplierFeatures.CreateEdit
{
    public class EditBrandSupplier : EditCommand, IRequest<Result<int>>
    {
       
        public int BrandId => Brand==null? 0 :Brand!.Id;
        public EditBrand? Brand { get; set; }

        public int SupplierId => Supplier==null? 0 : Supplier!.Id;
        public EditSupplier? Supplier { get; set; }

        public override void CreateMasterRelations<T1, T2>(T1 Master1, T2 Master2)
        {
            Brand = Master1 as EditBrand;
            Supplier = Master2 as EditSupplier;
        }
    }

}
