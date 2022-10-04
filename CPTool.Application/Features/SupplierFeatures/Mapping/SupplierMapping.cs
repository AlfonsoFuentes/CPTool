
using CPTool.Application.Features.SupplierFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.SupplierFeatures.Mapping
{
    internal class SupplierMapping : Profile
    {
        public SupplierMapping()
        {
            CreateMap<Supplier, AddEditSupplierCommand>()
                .ForMember(dest => dest.BrandSuppliersCommand, act => { act.PreCondition(src => (src.BrandSuppliers != null)); act.MapFrom(src => src.BrandSuppliers); })
                .ForMember(dest => dest.VendorCodeCommand, act => { act.PreCondition(src => (src.VendorCode != null)); act.MapFrom(src => src.VendorCode); })
                .ForMember(dest => dest.TaxCodeLDCommand, act => { act.PreCondition(src => (src.TaxCodeLD != null)); act.MapFrom(src => src.TaxCodeLD); })
                .ForMember(dest => dest.TaxCodeLPCommand, act => { act.PreCondition(src => (src.TaxCodeLP != null)); act.MapFrom(src => src.TaxCodeLP); });

            CreateMap<AddEditSupplierCommand, Supplier>();
        }
    }
}
