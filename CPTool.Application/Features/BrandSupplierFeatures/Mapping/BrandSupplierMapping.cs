
using CPTool.Application.Features.BrandSupplierFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.BrandSupplierFeatures.Mapping
{
    internal class BrandSupplierMapping : Profile
    {
        public BrandSupplierMapping()
        {
            CreateMap<BrandSupplier, AddEditBrandSupplierCommand>()
                .ForMember(dest => dest.BrandCommand, act => { act.PreCondition(src => (src.Brand != null)); act.MapFrom(src => src.Brand); })
            .ForMember(dest => dest.SupplierCommand, act => { act.PreCondition(src => (src.Supplier != null)); act.MapFrom(src => src.Supplier); });
            CreateMap<AddEditBrandSupplierCommand, BrandSupplier>();
        }
    }
}
