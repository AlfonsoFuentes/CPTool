global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.InsulationItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.InsulationItems.Profiles
{
    internal class InsulationItemMapping : Profile
    {
        public InsulationItemMapping()
        {
            CreateMap<InsulationItem, CommandInsulationItem>();
            CreateMap<CommandInsulationItem, InsulationItem>();
            CreateMap<AddInsulationItem, InsulationItem>();
            CreateMap<CommandInsulationItem, AddInsulationItem>();
        }
    }
}
