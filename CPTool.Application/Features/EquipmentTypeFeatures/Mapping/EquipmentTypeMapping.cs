
using CPTool.Application.Features.EquipmentTypeFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.EquipmentTypeFeatures.Mapping
{
    internal class EquipmentTypeMapping : Profile
    {
        public EquipmentTypeMapping()
        {
            CreateMap<EquipmentType, AddEditEquipmentTypeCommand>()
                .ForMember(dest => dest.EquipmentTypesSubCommand,
                act => { act.PreCondition(src => (src.EquipmentTypeSubs != null)); act.MapFrom(src => src.EquipmentTypeSubs); })
                .ForMember(dest => dest.EquipmentItemsCommand,
                act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); });

            CreateMap<AddEditEquipmentTypeCommand, EquipmentType>();
        }
    }
}
