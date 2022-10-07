
using CPTool.Application.Features.BrandFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.BrandFeatures.Mapping
{
    internal class BrandMapping : Profile
    {
        public BrandMapping()
        {
            CreateMap<Brand, AddEditBrandCommand>()
                .ForMember(dest => dest.BrandSuppliersCommand, 
                act => { act.PreCondition(src => (src.BrandSuppliers != null)); act.MapFrom(src => src.BrandSuppliers); })
                .ForMember(dest => dest.EquipmentItemsCommand,
                act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); })
                .ForMember(dest => dest.InstrumentItemsCommand,
                act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); })
                .ForMember(dest => dest.PurchaseOrdersCommand,
                act => { act.PreCondition(src => (src.PurchaseOrders != null)); act.MapFrom(src => src.PurchaseOrders); });

            CreateMap<AddEditBrandCommand, Brand>();
        }
    }
}
