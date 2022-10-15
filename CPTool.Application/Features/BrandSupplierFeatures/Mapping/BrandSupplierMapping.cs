
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;


namespace CPTool.Application.Features.BrandSupplierFeatures.Mapping
{
    internal class BrandSupplierMapping : Profile
    {
        public BrandSupplierMapping()
        {
            CreateMap<BrandSupplier,EditBrandSupplier>();
            CreateMap<EditBrandSupplier, BrandSupplier>();
            CreateMap<AddBrandSupplier, BrandSupplier>();
        }
    }
}
