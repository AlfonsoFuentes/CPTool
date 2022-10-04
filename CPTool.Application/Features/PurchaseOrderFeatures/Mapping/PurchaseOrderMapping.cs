



using CPTool.Application.Features.PurchaseOrderFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderFeatures.Mapping
{
    internal class PurchaseOrderMapping : Profile
    {
        public PurchaseOrderMapping()
        {
            CreateMap<PurchaseOrder, AddEditPurchaseOrderCommand>()
                .ForMember(dest => dest.MWOCommand, act => { act.PreCondition(src => (src.MWO != null)); act.MapFrom(src => src.MWO); });
           

            CreateMap<AddEditPurchaseOrderCommand, PurchaseOrder>();
        }
    }
}
