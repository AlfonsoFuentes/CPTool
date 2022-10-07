



using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Mapping
{
    internal class PurchaseOrderMWOItemMapping : Profile
    {
        public PurchaseOrderMWOItemMapping()
        {
            CreateMap<PurchaseOrderMWOItem, AddEditPurchaseOrderMWOItemCommand>()
                .ForMember(dest => dest.PurchaseOrderCommand, act => { act.PreCondition(src => (src.PurchaseOrder != null)); act.MapFrom(src => src.PurchaseOrder); })
                .ForMember(dest => dest.MWOItemCommand, act => { act.PreCondition(src => (src.MWOItem != null)); act.MapFrom(src => src.MWOItem); });
           

            CreateMap<AddEditPurchaseOrderMWOItemCommand, PurchaseOrderMWOItem>();
        }
    }
}
