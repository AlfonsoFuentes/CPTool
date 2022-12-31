global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Takss.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Takss.Profiles
{
    internal class TaksMapping : Profile
    {
        public TaksMapping()
        {
            CreateMap<Taks, CommandTaks>();
            CreateMap<CommandTaks, Taks>();
            CreateMap<AddTaks, Taks>();
            CreateMap<CommandTaks, AddTaks>();
        }
    }
}
