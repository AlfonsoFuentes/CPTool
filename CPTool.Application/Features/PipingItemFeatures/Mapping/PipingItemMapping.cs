



using CPTool.Application.Features.PipingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PipingItemFeatures.Mapping
{
    internal class PipingItemMapping : Profile
    {
        public PipingItemMapping()
        {
            CreateMap<PipingItem, EditPipingItem>();

            CreateMap<EditPipingItem, PipingItem>();
            CreateMap<AddPipingItem, PipingItem>();
        }
    }
}
