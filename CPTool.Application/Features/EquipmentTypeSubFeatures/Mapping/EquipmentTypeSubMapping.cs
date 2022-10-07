




namespace CPTool.Application.Features.EquipmentTypeSubFeatures.Mapping
{
    internal class EquipmentTypeSubMapping : Profile
    {
        public EquipmentTypeSubMapping()
        {
            CreateMap<EquipmentTypeSub, AddEditEquipmentTypeSubCommand>()
                .ForMember(dest => dest.EquipmentTypeCommand,
                act => { act.PreCondition(src => (src.EquipmentType != null)); act.MapFrom(src => src.EquipmentType); })
                .ForMember(dest => dest.EquipmentItemsCommand,
                act => { act.PreCondition(src => (src.EquipmentItems != null)); act.MapFrom(src => src.EquipmentItems); }); ;

            CreateMap<AddEditEquipmentTypeSubCommand, EquipmentTypeSub>();
        }
    }
}
