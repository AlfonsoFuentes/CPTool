




namespace CPTool.Application.Features.EquipmentTypeSubFeatures.Mapping
{
    internal class EquipmentTypeSubMapping : Profile
    {
        public EquipmentTypeSubMapping()
        {
            CreateMap<EquipmentTypeSub, EditEquipmentTypeSub>();

            CreateMap<AddEquipmentTypeSub, EquipmentTypeSub>();
            CreateMap<EditEquipmentTypeSub, EquipmentTypeSub>();
        }
    }
}
