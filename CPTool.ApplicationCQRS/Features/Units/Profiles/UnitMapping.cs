global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Units.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Units.Profiles
{
    internal class UnitMapping : Profile
    {
        public UnitMapping()
        {
            CreateMap<EntityUnit, CommandUnit>();
            CreateMap<CommandUnit, EntityUnit>();
            CreateMap<AddUnit, EntityUnit>();
            CreateMap<CommandUnit, AddUnit>();
        }
    }
}
