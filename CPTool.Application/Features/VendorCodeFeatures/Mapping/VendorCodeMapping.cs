



using CPTool.Application.Features.VendorCodeFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.VendorCodeFeatures.Mapping
{
    internal class VendorCodeMapping : Profile
    {
        public VendorCodeMapping()
        {
            CreateMap<VendorCode, AddEditVendorCodeCommand>();

            CreateMap<AddEditVendorCodeCommand, VendorCode>();
        }
    }
}
