



using CPTool.Application.Features.SignalsFeatures.CreateEdit;


namespace CPTool.Application.Features.SignalsFeatures.Mapping
{
    internal class SignalMapping : Profile
    {
        public SignalMapping()
        {
            CreateMap<Signal, EditSignal>();
            CreateMap<AddSignal, Signal>();
            CreateMap<EditSignal, Signal>();
            CreateMap<EditSignal, AddSignal>();
        }
    }
}
