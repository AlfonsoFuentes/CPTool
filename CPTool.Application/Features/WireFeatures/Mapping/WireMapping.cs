



using CPTool.Application.Features.WireFeatures.CreateEdit;

namespace CPTool.Application.Features.WireFeatures.Mapping
{
    internal class WireMapping : Profile
    {
        public WireMapping()
        {
            CreateMap<Wire,EditWire>();
            CreateMap<EditWire, AddWire>();
            CreateMap<EditWire, Wire>();
            CreateMap<AddWire, Wire>();
        }
    }
}
