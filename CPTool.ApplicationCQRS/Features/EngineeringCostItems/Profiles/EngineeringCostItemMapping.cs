global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.EngineeringCostItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.EngineeringCostItems.Profiles
{
    internal class EngineeringCostItemMapping : Profile
    {
        public EngineeringCostItemMapping()
        {
            CreateMap<EngineeringCostItem, CommandEngineeringCostItem>();
            CreateMap<CommandEngineeringCostItem, EngineeringCostItem>();
            CreateMap<AddEngineeringCostItem, EngineeringCostItem>();
            CreateMap<CommandEngineeringCostItem, AddEngineeringCostItem>();
        }
    }
}
