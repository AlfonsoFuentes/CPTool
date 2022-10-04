
using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.BrandFeatures.Mapping
{
    internal class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, AddEditBrandCommand>()
                .ForMember(dest => dest.BrandSuppliersCommand, act => { act.PreCondition(src => (src.BrandSuppliers != null)); act.MapFrom(src => src.BrandSuppliers); });

            CreateMap<AddEditBrandCommand, Brand>();
        }
    }
}
