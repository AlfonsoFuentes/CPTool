



using CPTool.Application.Features.EquipmentItemFeatures.CreateEdit;

namespace CPTool.Application.Features.EquipmentItemFeatures.Mapping
{
    internal class EquipmentItemMapping : Profile
    {
        public EquipmentItemMapping()
        {
            CreateMap<EquipmentItem, EditEquipmentItem>();


            CreateMap<EditEquipmentItem, EquipmentItem>();
            CreateMap<AddEquipmentItem, EquipmentItem>();
            CreateMap<EditEquipmentItem, AddEquipmentItem>();

        }
    }
}
