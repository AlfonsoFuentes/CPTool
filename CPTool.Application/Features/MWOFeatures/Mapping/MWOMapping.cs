



using CPTool.Application.Features.MWOFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOFeatures.Mapping
{
    internal class MWOMapping : Profile
    {
        public MWOMapping()
        {
            CreateMap<MWO, EditMWO>();
            CreateMap<EditMWO, MWO>();
            CreateMap<AddMWO, MWO>();
            CreateMap<EditMWO, AddMWO>();
        }
    }
}
