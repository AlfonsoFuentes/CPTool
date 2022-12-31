global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypeSubs.Profiles
{
    internal class EquipmentTypeSubMapping : Profile
    {
        public EquipmentTypeSubMapping()
        {
            CreateMap<EquipmentTypeSub, CommandEquipmentTypeSub>();
            CreateMap<CommandEquipmentTypeSub, EquipmentTypeSub>();
            CreateMap<AddEquipmentTypeSub, EquipmentTypeSub>();
            CreateMap<CommandEquipmentTypeSub, AddEquipmentTypeSub>();
        }
    }
}
