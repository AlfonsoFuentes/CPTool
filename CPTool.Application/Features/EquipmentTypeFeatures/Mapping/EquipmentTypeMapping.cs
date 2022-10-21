
using CPTool.Application.Features.EquipmentTypeFeatures.CreateEdit;


namespace CPTool.Application.Features.EquipmentTypeFeatures.Mapping
{
    internal class EquipmentTypeMapping : Profile
    {
        public EquipmentTypeMapping()
        {
            CreateMap<EquipmentType,EditEquipmentType>();


            CreateMap<AddEquipmentType, EquipmentType>();
            CreateMap<EditEquipmentType, EquipmentType>();
            CreateMap<EditEquipmentType, AddEquipmentType>();
        }
    }
}
