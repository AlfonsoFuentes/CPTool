using CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.PaintingItemFeatures.CreateEdit;

namespace CPTool.Application.Features.MWOItemFeatures.MWOItemInternalFeatures.PaintingItemFeatures.Mapping
{
    internal class PaintingItemMapping : Profile
    {
        public PaintingItemMapping()
        {
            CreateMap<PaintingItem, AddEditPaintingItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => src.MWOItems != null); act.MapFrom(src => src.MWOItems); });
              


            CreateMap<AddEditPaintingItemCommand, PaintingItem>();
        }
    }

}
