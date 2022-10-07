



using CPTool.Application.Features.PipeDiameterFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipeDiameterFeatures.Mapping
{
    internal class PipeDiameterMapping : Profile
    {
        public PipeDiameterMapping()
        {
            CreateMap<PipeDiameter, AddEditPipeDiameterCommand>()
                .ForMember(dest => dest.PipingItemsCommandCommand, act => { act.PreCondition(src => (src.PipingItems != null)); act.MapFrom(src => src.PipingItems); })
                .ForMember(dest => dest.NozzlesCommandCommand, act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); })
                .ForMember(dest => dest.ODCommand, act => { act.PreCondition(src => (src.OD != null)); act.MapFrom(src => src.OD); })
                .ForMember(dest => dest.IDCommand, act => { act.PreCondition(src => (src.ID != null)); act.MapFrom(src => src.ID); })
                .ForMember(dest => dest.ThicknessCommand, act => { act.PreCondition(src => (src.Thickness != null)); act.MapFrom(src => src.Thickness); });
           

            CreateMap<AddEditPipeDiameterCommand, PipeDiameter>();
        }
    }
}
