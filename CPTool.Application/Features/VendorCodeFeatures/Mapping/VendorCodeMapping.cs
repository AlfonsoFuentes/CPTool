



using CPTool.Application.Features.VendorCodeFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.VendorCodeFeatures.Mapping
{
    internal class VendorCodeMapping : Profile
    {
        public VendorCodeMapping()
        {
            CreateMap<VendorCode, AddEditVendorCodeCommand>()
                .ForMember(dest => dest.SuppliersCommand, act => { act.PreCondition(src => (src.Suppliers != null)); act.MapFrom(src => src.Suppliers); }); ;

            CreateMap<AddEditVendorCodeCommand, VendorCode>();
        }
    }
}
