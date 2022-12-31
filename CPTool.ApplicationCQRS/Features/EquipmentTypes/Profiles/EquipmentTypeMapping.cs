global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.EquipmentTypes.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.EquipmentTypes.Profiles
{
    internal class EquipmentTypeMapping : Profile
    {
        public EquipmentTypeMapping()
        {
            CreateMap<EquipmentType, CommandEquipmentType>();
            CreateMap<CommandEquipmentType, EquipmentType>();
            CreateMap<AddEquipmentType, EquipmentType>();
            CreateMap<CommandEquipmentType, AddEquipmentType>();
        }
    }
}
