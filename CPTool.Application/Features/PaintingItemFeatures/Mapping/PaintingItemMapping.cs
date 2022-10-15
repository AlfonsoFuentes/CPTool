



using CPTool.Application.Features.PaintingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.PaintingItemFeatures.Mapping
{
    internal class PaintingItemMapping : Profile
    {
        public PaintingItemMapping()
        {
            CreateMap<PaintingItem, EditPaintingItem>();
            CreateMap<EditPaintingItem, PaintingItem>();
            CreateMap<AddPaintingItem, PaintingItem>();
        }
    }
}
