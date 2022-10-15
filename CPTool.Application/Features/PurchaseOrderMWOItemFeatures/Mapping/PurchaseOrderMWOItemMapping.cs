



using CPTool.Application.Features.PurchaseOrderMWOItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PurchaseOrderMWOItemFeatures.Mapping
{
    internal class PurchaseOrderMWOItemMapping : Profile
    {
        public PurchaseOrderMWOItemMapping()
        {
            CreateMap<PurchaseOrderMWOItem, EditPurchaseOrderMWOItem>();
            CreateMap<EditPurchaseOrderMWOItem, PurchaseOrderMWOItem>();
            CreateMap<AddPurchaseOrderMWOItem, PurchaseOrderMWOItem>();
        }
    }
}
