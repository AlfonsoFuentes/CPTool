
using CPTool.Application.Features.BrandFeatures.CreateEdit;


namespace CPTool.Application.Features.BrandFeatures.Mapping
{
    internal class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, EditBrand>()
                 .ForMember(dest => dest.BrandOriginalId, act => act.MapFrom(src => src.Id));
               

            CreateMap<AddBrand, Brand>();
            CreateMap<EditBrand, Brand>();
            CreateMap<EditBrand, AddBrand>();
        }
    }
}
