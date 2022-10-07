



using CPTool.Application.Features.InstrumentItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.InstrumentItemFeatures.Mapping
{
    internal class InstrumentItemMapping : Profile
    {
        public InstrumentItemMapping()
        {
            CreateMap<InstrumentItem, AddEditInstrumentItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
                .ForMember(dest => dest.ProcessConditionCommand, act => { act.PreCondition(src => (src.ProcessCondition != null)); act.MapFrom(src => src.ProcessCondition); })
                .ForMember(dest => dest.ProcessFluidCommand, act => { act.PreCondition(src => (src.ProcessFluid != null)); act.MapFrom(src => src.ProcessFluid); })
                .ForMember(dest => dest.NozzlesCommand, act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); })
                .ForMember(dest => dest.GasketCommand, act => { act.PreCondition(src => (src.Gasket != null)); act.MapFrom(src => src.Gasket); })
                .ForMember(dest => dest.iInnerMaterialCommand, act => { act.PreCondition(src => (src.iInnerMaterial != null)); act.MapFrom(src => src.iInnerMaterial); })
                .ForMember(dest => dest.iOuterMaterialCommand, act => { act.PreCondition(src => (src.iOuterMaterial != null)); act.MapFrom(src => src.iOuterMaterial); })
                .ForMember(dest => dest.MeasuredVariableCommand, act => { act.PreCondition(src => (src.MeasuredVariable != null)); act.MapFrom(src => src.MeasuredVariable); })
                .ForMember(dest => dest.MeasuredVariableModifierCommand, act => { act.PreCondition(src => (src.MeasuredVariableModifier != null)); act.MapFrom(src => src.MeasuredVariableModifier); })
                .ForMember(dest => dest.DeviceFunctionCommand, act => { act.PreCondition(src => (src.DeviceFunction != null)); act.MapFrom(src => src.DeviceFunction); })
                .ForMember(dest => dest.DeviceFunctionModifierCommand, act => { act.PreCondition(src => (src.DeviceFunctionModifier != null)); act.MapFrom(src => src.DeviceFunctionModifier); })
                .ForMember(dest => dest.ReadoutCommand, act => { act.PreCondition(src => (src.Readout != null)); act.MapFrom(src => src.Readout); })
                .ForMember(dest => dest.BrandCommand, act => { act.PreCondition(src => (src.Brand != null)); act.MapFrom(src => src.Brand); })
                .ForMember(dest => dest.SupplierCommand, act => { act.PreCondition(src => (src.Supplier != null)); act.MapFrom(src => src.Supplier); });
           

            CreateMap<AddEditInstrumentItemCommand, InstrumentItem>()
                 .ForMember(dest => dest.ProcessCondition, act => { act.PreCondition(src => (src.ProcessConditionCommand != null)); act.MapFrom(src => src.ProcessConditionCommand); });
        }
    }
}
