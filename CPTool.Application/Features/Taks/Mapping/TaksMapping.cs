



using CPTool.Application.Features.TaksFeatures.CreateEdit;

namespace CPTool.Application.Features.TaksFeatures.Mapping
{
    internal class TaksMapping : Profile
    {
        public TaksMapping()
        {
            CreateMap<Taks, EditTaks>();
            CreateMap<EditTaks, AddTaks>();
            CreateMap<EditTaks, Taks>();
            CreateMap<AddTaks, Taks>();
        }
    }
}
