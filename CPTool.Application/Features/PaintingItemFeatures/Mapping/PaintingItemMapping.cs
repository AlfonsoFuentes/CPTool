



using CPTool.Application.Features.PaintingItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PaintingItemFeatures.Mapping
{
    internal class PaintingItemMapping : Profile
    {
        public PaintingItemMapping()
        {
            CreateMap<PaintingItem, AddEditPaintingItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); });
           

            CreateMap<AddEditPaintingItemCommand, PaintingItem>();
        }
    }
}
