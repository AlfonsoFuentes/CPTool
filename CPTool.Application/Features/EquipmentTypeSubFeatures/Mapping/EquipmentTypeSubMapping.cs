




namespace CPTool.Application.Features.EquipmentTypeSubFeatures.Mapping
{
    internal class EquipmentTypeSubMapping : Profile
    {
        public EquipmentTypeSubMapping()
        {
            CreateMap<EquipmentTypeSub, AddEditEquipmentTypeSubCommand>();

            CreateMap<AddEditEquipmentTypeSubCommand, EquipmentTypeSub>();
        }
    }
}
