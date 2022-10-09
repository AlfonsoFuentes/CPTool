



using CPTool.Application.Features.PipeDiameterFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.PipeDiameterFeatures.Mapping
{
    internal class PipeDiameterMapping : Profile
    {
        public PipeDiameterMapping()
        {
            CreateMap<PipeDiameter, AddEditPipeDiameterCommand>()
                .ForMember(dest => dest.PipeClassCommand, act => { act.PreCondition(src => (src.PipeClass != null)); act.MapFrom(src => src.PipeClass); })
                .ForMember(dest => dest.PipingItemsCommandCommand, act => { act.PreCondition(src => (src.PipingItems != null)); act.MapFrom(src => src.PipingItems); })
                .ForMember(dest => dest.NozzlesCommandCommand, act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); })
                .ForMember(dest => dest.ODCommand, act => { act.PreCondition(src => (src.OuterDiameter != null)); act.MapFrom(src => src.OuterDiameter); })
                .ForMember(dest => dest.IDCommand, act => { act.PreCondition(src => (src.InternalDiameter != null)); act.MapFrom(src => src.InternalDiameter); })
                .ForMember(dest => dest.ThicknessCommand, act => { act.PreCondition(src => (src.Thickness != null)); act.MapFrom(src => src.Thickness); });
           

            CreateMap<AddEditPipeDiameterCommand, PipeDiameter>()
                .ForMember(dest => dest.OuterDiameter, act => { act.PreCondition(src => (src.ODCommand != null)); act.MapFrom(src => src.ODCommand); })
                .ForMember(dest => dest.InternalDiameter, act => { act.PreCondition(src => (src.IDCommand != null)); act.MapFrom(src => src.IDCommand); })
                .ForMember(dest => dest.Thickness, act => { act.PreCondition(src => (src.ThicknessCommand != null)); act.MapFrom(src => src.ThicknessCommand); });
            
        }
    }
}
