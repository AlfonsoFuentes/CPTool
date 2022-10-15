



using CPTool.Application.Features.FoundationItemFeatures.CreateEdit;

namespace CPTool.Application.Features.FoundationItemFeatures.Mapping
{
    internal class FoundationItemMapping : Profile
    {
        public FoundationItemMapping()
        {
            CreateMap<FoundationItem, AddFoundationItem>();

            CreateMap<AddFoundationItem, FoundationItem>();
            CreateMap<EditFoundationItem, FoundationItem>();
        }
    }
}
