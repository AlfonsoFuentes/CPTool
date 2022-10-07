



using CPTool.Application.Features.UnitFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.UnitFeatures.Mapping
{
    internal class UnitMapping : Profile
    {
        public UnitMapping()
        {
            CreateMap<CPTool.Domain.Entities.Unit, AddEditUnitCommand>()
                .ForMember(dest => dest.ODsCommand, act => { act.PreCondition(src => (src.ODs != null)); act.MapFrom(src => src.ODs); })
                .ForMember(dest => dest.IDsCommand, act => { act.PreCondition(src => (src.IDs != null)); act.MapFrom(src => src.IDs); })
                .ForMember(dest => dest.ThicknesssCommand, act => { act.PreCondition(src => (src.Thicknesss != null)); act.MapFrom(src => src.Thicknesss); })
                .ForMember(dest => dest.SpecificCpsCommand, act => { act.PreCondition(src => (src.SpecificCps != null)); act.MapFrom(src => src.SpecificCps); })
                .ForMember(dest => dest.ThermalConductivitysCommand, act => { act.PreCondition(src => (src.ThermalConductivitys != null)); act.MapFrom(src => src.ThermalConductivitys); })
                .ForMember(dest => dest.SpecificEnthalpysCommand, act => { act.PreCondition(src => (src.SpecificEnthalpys != null)); act.MapFrom(src => src.SpecificEnthalpys); })
                .ForMember(dest => dest.EnthalpyFlowsCommand, act => { act.PreCondition(src => (src.EnthalpyFlows != null)); act.MapFrom(src => src.EnthalpyFlows); })
                .ForMember(dest => dest.ViscositysCommand, act => { act.PreCondition(src => (src.Viscositys != null)); act.MapFrom(src => src.Viscositys); })
                .ForMember(dest => dest.DensitysCommand, act => { act.PreCondition(src => (src.Densitys != null)); act.MapFrom(src => src.Densitys); })
                .ForMember(dest => dest.VolumetricFlowsCommand, act => { act.PreCondition(src => (src.VolumetricFlows != null)); act.MapFrom(src => src.VolumetricFlows); })
                .ForMember(dest => dest.MassFlowsCommand, act => { act.PreCondition(src => (src.MassFlows != null)); act.MapFrom(src => src.MassFlows); })
                .ForMember(dest => dest.TemperaturesCommand, act => { act.PreCondition(src => (src.Temperatures != null)); act.MapFrom(src => src.Temperatures); })
                .ForMember(dest => dest.PressuresCommand, act => { act.PreCondition(src => (src.Pressures != null)); act.MapFrom(src => src.Pressures); })
                .ForMember(dest => dest.FrictionPipeAccesorysCommand, act => { act.PreCondition(src => (src.FrictionPipeAccesorys != null)); act.MapFrom(src => src.FrictionPipeAccesorys); })
                .ForMember(dest => dest.ReynoldPipeAccesorysCommand, act => { act.PreCondition(src => (src.ReynoldPipeAccesorys != null)); act.MapFrom(src => src.ReynoldPipeAccesorys); })
                .ForMember(dest => dest.LevelInletPipeAccesorysCommand, act => { act.PreCondition(src => (src.LevelInletPipeAccesorys != null)); act.MapFrom(src => src.LevelInletPipeAccesorys); })
                .ForMember(dest => dest.LevelOutletPipeAccesorysCommand, act => { act.PreCondition(src => (src.LevelOutletPipeAccesorys != null)); act.MapFrom(src => src.LevelOutletPipeAccesorys); })
                .ForMember(dest => dest.FrictionDropPressurePipeAccesorysCommand, act => { act.PreCondition(src => (src.FrictionDropPressurePipeAccesorys != null)); act.MapFrom(src => src.FrictionDropPressurePipeAccesorys); })
                .ForMember(dest => dest.OverallDropPressurePipeAccesorysCommand, act => { act.PreCondition(src => (src.OverallDropPressurePipeAccesorys != null)); act.MapFrom(src => src.OverallDropPressurePipeAccesorys); })
                .ForMember(dest => dest.ElevationChangePipeAccesorysCommand, act => { act.PreCondition(src => (src.ElevationChangePipeAccesorys != null)); act.MapFrom(src => src.ElevationChangePipeAccesorys); })
                ;
           

            CreateMap<AddEditUnitCommand, Unit>();
        }
    }
}
