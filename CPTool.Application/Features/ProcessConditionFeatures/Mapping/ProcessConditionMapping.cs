



using CPTool.Application.Features.ProcessConditionFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.ProcessConditionFeatures.Mapping
{
    internal class ProcessConditionMapping : Profile
    {
        public ProcessConditionMapping()
        {
            CreateMap<ProcessCondition, AddEditProcessConditionCommand>()
                .ForMember(dest => dest.PipeAccesorysCommand, act => { act.PreCondition(src => (src.PipeAccesorys != null)); act.MapFrom(src => src.PipeAccesorys); })
                .ForMember(dest => dest.EquipmentItemsCommand, act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); })
                .ForMember(dest => dest.InstrumentItemsCommand, act => { act.PreCondition(src => (src.InstrumentItems != null)); act.MapFrom(src => src.InstrumentItems); })
                .ForMember(dest => dest.PressureCommand, act => { act.PreCondition(src => (src.Pressure != null)); act.MapFrom(src => src.Pressure); })
                .ForMember(dest => dest.TemperatureCommand, act => { act.PreCondition(src => (src.Temperature != null)); act.MapFrom(src => src.Temperature); })
                .ForMember(dest => dest.MassFlowCommand, act => { act.PreCondition(src => (src.MassFlow != null)); act.MapFrom(src => src.MassFlow); })
                .ForMember(dest => dest.VolumetricFlowCommand, act => { act.PreCondition(src => (src.VolumetricFlow != null)); act.MapFrom(src => src.VolumetricFlow); })
                .ForMember(dest => dest.DensityCommand, act => { act.PreCondition(src => (src.Density != null)); act.MapFrom(src => src.Density); })
                .ForMember(dest => dest.ViscosityCommand, act => { act.PreCondition(src => (src.Viscosity != null)); act.MapFrom(src => src.Viscosity); })
                .ForMember(dest => dest.EnthalpyFlowCommand, act => { act.PreCondition(src => (src.EnthalpyFlow != null)); act.MapFrom(src => src.EnthalpyFlow); })
                .ForMember(dest => dest.SpecificEnthalpyCommand, act => { act.PreCondition(src => (src.SpecificEnthalpy != null)); act.MapFrom(src => src.SpecificEnthalpy); })
                .ForMember(dest => dest.ThermalConductivityCommand, act => { act.PreCondition(src => (src.ThermalConductivity != null)); act.MapFrom(src => src.ThermalConductivity); })
                .ForMember(dest => dest.SpecificCpCommand, act => { act.PreCondition(src => (src.SpecificCp != null)); act.MapFrom(src => src.SpecificCp); });
           

            CreateMap<AddEditProcessConditionCommand, ProcessCondition>()
                .ForMember(dest => dest.Pressure, act => { act.PreCondition(src => (src.PressureCommand != null)); act.MapFrom(src => src.PressureCommand); })
                .ForMember(dest => dest.Temperature, act => { act.PreCondition(src => (src.TemperatureCommand != null)); act.MapFrom(src => src.TemperatureCommand); })
                .ForMember(dest => dest.MassFlow, act => { act.PreCondition(src => (src.MassFlowCommand != null)); act.MapFrom(src => src.MassFlowCommand); })
                .ForMember(dest => dest.VolumetricFlow, act => { act.PreCondition(src => (src.VolumetricFlowCommand != null)); act.MapFrom(src => src.VolumetricFlowCommand); })
                .ForMember(dest => dest.Density, act => { act.PreCondition(src => (src.DensityCommand != null)); act.MapFrom(src => src.DensityCommand); })
                .ForMember(dest => dest.Viscosity, act => { act.PreCondition(src => (src.ViscosityCommand != null)); act.MapFrom(src => src.ViscosityCommand); })
                .ForMember(dest => dest.EnthalpyFlow, act => { act.PreCondition(src => (src.EnthalpyFlowCommand != null)); act.MapFrom(src => src.EnthalpyFlowCommand); })
                .ForMember(dest => dest.SpecificEnthalpy, act => { act.PreCondition(src => (src.SpecificEnthalpyCommand != null)); act.MapFrom(src => src.SpecificEnthalpyCommand); })
                .ForMember(dest => dest.ThermalConductivity, act => { act.PreCondition(src => (src.ThermalConductivityCommand != null)); act.MapFrom(src => src.ThermalConductivityCommand); })
                .ForMember(dest => dest.SpecificCp, act => { act.PreCondition(src => (src.SpecificCpCommand != null)); act.MapFrom(src => src.SpecificCpCommand); });
            ;
        }
    }
}
