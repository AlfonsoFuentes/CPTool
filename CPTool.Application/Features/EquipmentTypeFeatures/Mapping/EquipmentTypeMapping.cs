
using CPTool.Application.Features.EquipmentTypeFeatures.Command.CreateEdit;


namespace CPTool.Application.Features.EquipmentTypeFeatures.Mapping
{
    internal class EquipmentTypeMapping : Profile
    {
        public EquipmentTypeMapping()
        {
            CreateMap<EquipmentType, AddEditEquipmentTypeCommand>()
                .ForMember(dest => dest.EquipmentTypesSub, act => { act.PreCondition(src => (src.EquipmentTypeSubs != null)); act.MapFrom(src => src.EquipmentTypeSubs); });

            CreateMap<AddEditEquipmentTypeCommand, EquipmentType>();
        }
    }
}
