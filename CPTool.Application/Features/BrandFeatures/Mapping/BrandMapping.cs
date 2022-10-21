
using CPTool.Application.Features.BrandFeatures.CreateEdit;


namespace CPTool.Application.Features.BrandFeatures.Mapping
{
    internal class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, EditBrand>();

            CreateMap<AddBrand, Brand>();
            CreateMap<EditBrand, Brand>();
            CreateMap<EditBrand, AddBrand>();
        }
    }
}
