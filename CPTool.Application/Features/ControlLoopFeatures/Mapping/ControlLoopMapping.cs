



using CPTool.Application.Features.ControlLoopFeatures.CreateEdit;

namespace CPTool.Application.Features.ControlLoopFeatures.Mapping
{
    internal class ControlLoopMapping : Profile
    {
        public ControlLoopMapping()
        {
            CreateMap<ControlLoop, EditControlLoop>();

            CreateMap<EditControlLoop, ControlLoop>();
            CreateMap<AddControlLoop, ControlLoop>();
            CreateMap<EditControlLoop, AddControlLoop>();
        }
    }
}
