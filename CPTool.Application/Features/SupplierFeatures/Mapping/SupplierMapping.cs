
using CPTool.Application.Features.SupplierFeatures.CreateEdit;


namespace CPTool.Application.Features.SupplierFeatures.Mapping
{
    internal class SupplierMapping : Profile
    {
        public SupplierMapping()
        {
            CreateMap<Supplier, EditSupplier>();
            CreateMap<EditSupplier, Supplier>();
            CreateMap<AddSupplier, Supplier>();
            CreateMap<EditSupplier, AddSupplier>();
        }
    }
}
