



using CPTool.Application.Features.NozzleFeatures.CreateEdit;

namespace CPTool.Application.Features.NozzleFeatures.Mapping
{
    internal class NozzleMapping : Profile
    {
        public NozzleMapping()
        {
            CreateMap<Nozzle, EditNozzle>();

            CreateMap<EditNozzle, Nozzle>();
            CreateMap<AddNozzle, Nozzle>();
            CreateMap<EditNozzle, AddNozzle>();
        }
    }
}
