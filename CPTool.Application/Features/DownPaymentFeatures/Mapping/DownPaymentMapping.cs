



using CPTool.Application.Features.DownPaymentFeatures.CreateEdit;

namespace CPTool.Application.Features.DownPaymentFeatures.Mapping
{
    internal class DownPaymentMapping : Profile
    {
        public DownPaymentMapping()
        {
            CreateMap<DownPayment, EditDownPayment>();

            CreateMap<AddDownPayment, DownPayment>();
            CreateMap<EditDownPayment, DownPayment>();
            CreateMap<EditDownPayment, AddDownPayment>();
        }
    }
}
