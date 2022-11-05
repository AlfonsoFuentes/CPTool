
using CPTool.Application.Features.BrandSupplierFeatures.CreateEdit;


namespace CPTool.Application.Features.BrandSupplierFeatures.Mapping
{
    internal class BrandSupplierMapping : Profile
    {
        public BrandSupplierMapping()
        {
            CreateMap<BrandSupplier, EditBrandSupplier>()
                .ForMember(dest => dest.SupplierOriginalId, act => act.MapFrom(src => src.SupplierId))
                .ForMember(dest => dest.BrandOriginalId, act => act.MapFrom(src => src.BrandId)); ;
               
            CreateMap<EditBrandSupplier, BrandSupplier>();
            CreateMap<AddBrandSupplier, BrandSupplier>();
            CreateMap<EditBrandSupplier, AddBrandSupplier>();

        }
    }
}
