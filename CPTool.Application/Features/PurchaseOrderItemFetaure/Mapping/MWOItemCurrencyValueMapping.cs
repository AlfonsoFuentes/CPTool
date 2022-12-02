

using CPTool.Application.Features.PurchaseOrderItemFeature.Command.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderItemFeatures.Mapping
{
    internal class PurchaseOrderItemMapping : Profile
    {
        public PurchaseOrderItemMapping()
        {
           

            CreateMap<PurchaseOrderItem, EditPurchaseOrderItem>();
            CreateMap<EditPurchaseOrderItem, PurchaseOrderItem>();
            CreateMap<EditPurchaseOrderItem, AddPurchaseOrderItem>();
            CreateMap<AddPurchaseOrderItem, PurchaseOrderItem>();

        }
    }
    
}
