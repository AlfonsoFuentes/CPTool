global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.FieldLocations.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.FieldLocations.Profiles
{
    internal class FieldLocationMapping : Profile
    {
        public FieldLocationMapping()
        {
            CreateMap<FieldLocation, CommandFieldLocation>();
            CreateMap<CommandFieldLocation, FieldLocation>();
            CreateMap<AddFieldLocation, FieldLocation>();
            CreateMap<CommandFieldLocation, AddFieldLocation>();
        }
    }
}
