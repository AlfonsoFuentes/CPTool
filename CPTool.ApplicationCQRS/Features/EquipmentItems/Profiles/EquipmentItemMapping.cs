global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.EquipmentItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.EquipmentItems.Profiles
{
    internal class EquipmentItemMapping : Profile
    {
        public EquipmentItemMapping()
        {
            CreateMap<EquipmentItem, CommandEquipmentItem>();
            CreateMap<CommandEquipmentItem, EquipmentItem>();
            CreateMap<AddEquipmentItem, EquipmentItem>();
            CreateMap<CommandEquipmentItem, AddEquipmentItem>();
            CreateMap<CommandEquipmentItem, UpdateEquipmentItem>();
            CreateMap<UpdateEquipmentItem, EquipmentItem>();
        }
    }
}
