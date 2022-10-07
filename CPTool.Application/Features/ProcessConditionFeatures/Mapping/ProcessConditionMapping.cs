



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
           

            CreateMap<AddEditProcessConditionCommand, ProcessCondition>();
        }
    }
}
