



using CPTool.Application.Features.PurchaseOrderFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderFeatures.Mapping
{
    internal class PurchaseOrderMapping : Profile
    {
        public PurchaseOrderMapping()
        {
            CreateMap<PurchaseOrder, EditPurchaseOrder>();
            CreateMap<EditPurchaseOrder, PurchaseOrder>();
            CreateMap<AddPurchaseOrder, PurchaseOrder>();
        }
    }
}
