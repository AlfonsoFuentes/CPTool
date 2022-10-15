



using CPTool.Application.Features.ReadoutFeatures.CreateEdit;

namespace CPTool.Application.Features.ReadoutFeatures.Mapping
{
    internal class ReadoutMapping : Profile
    {
        public ReadoutMapping()
        {
            CreateMap<Readout, EditReadout>();

            CreateMap<EditReadout, Readout>();
            CreateMap<AddReadout, Readout>();
        }
    }
}
