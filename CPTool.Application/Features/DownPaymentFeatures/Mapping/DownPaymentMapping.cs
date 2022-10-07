



using CPTool.Application.Features.DownPaymentFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.DownPaymentFeatures.Mapping
{
    internal class DownPaymentMapping : Profile
    {
        public DownPaymentMapping()
        {
            CreateMap<DownPayment, AddEditDownPaymentCommand>()
                .ForMember(dest => dest.PurchaseOrderCommand, act => { act.PreCondition(src => (src.PurchaseOrder != null)); act.MapFrom(src => src.PurchaseOrder); });
           

            CreateMap<AddEditDownPaymentCommand, DownPayment>();
        }
    }
}
