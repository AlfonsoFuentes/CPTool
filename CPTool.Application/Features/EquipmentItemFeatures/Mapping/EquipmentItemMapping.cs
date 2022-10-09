



using CPTool.Application.Features.EquipmentItemFeatures.Command.CreateEdit;

namespace CPTool.Application.Features.EquipmentItemFeatures.Mapping
{
    internal class EquipmentItemMapping : Profile
    {
        public EquipmentItemMapping()
        {
            CreateMap<EquipmentItem, AddEditEquipmentItemCommand>()
                .ForMember(dest => dest.MWOItemsCommand, act => { act.PreCondition(src => (src.MWOItems != null)); act.MapFrom(src => src.MWOItems); })
                .ForMember(dest => dest.NozzlesCommand, act => { act.PreCondition(src => (src.Nozzles != null)); act.MapFrom(src => src.Nozzles); })
                .ForMember(dest => dest.ProcessConditionCommand, act => { act.PreCondition(src => (src.ProcessCondition != null)); act.MapFrom(src => src.ProcessCondition); })
                .ForMember(dest => dest.GasketCommand, act => { act.PreCondition(src => (src.Gasket != null)); act.MapFrom(src => src.Gasket); })
                .ForMember(dest => dest.eInnerMaterialCommand, act => { act.PreCondition(src => (src.eInnerMaterial != null)); act.MapFrom(src => src.eInnerMaterial); })
                .ForMember(dest => dest.eOuterMaterialCommand, act => { act.PreCondition(src => (src.eOuterMaterial != null)); act.MapFrom(src => src.eOuterMaterial); })
                .ForMember(dest => dest.EquipmentTypeCommand, act => { act.PreCondition(src => (src.EquipmentType != null)); act.MapFrom(src => src.EquipmentType); })
                .ForMember(dest => dest.EquipmentTypeSubCommand, act => { act.PreCondition(src => (src.EquipmentTypeSub != null)); act.MapFrom(src => src.EquipmentTypeSub); })
                .ForMember(dest => dest.BrandCommand, act => { act.PreCondition(src => (src.Brand != null)); act.MapFrom(src => src.Brand); })
                .ForMember(dest => dest.SupplierCommand, act => { act.PreCondition(src => (src.Supplier != null)); act.MapFrom(src => src.Supplier); });


            CreateMap<AddEditEquipmentItemCommand, EquipmentItem>()
                .ForMember(dest => dest.ProcessCondition,
                act => { act.PreCondition(src => (src.ProcessConditionId == 0)); act.MapFrom(src => src.ProcessConditionCommand); });

        }
    }
}
