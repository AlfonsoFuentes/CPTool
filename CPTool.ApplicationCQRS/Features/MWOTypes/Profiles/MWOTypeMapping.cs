global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.MWOTypes.Profiles
{
    internal class MWOTypeMapping : Profile
    {
        public MWOTypeMapping()
        {
            CreateMap<MWOType, CommandMWOType>();
            CreateMap<CommandMWOType, MWOType>();
            CreateMap<AddMWOType, MWOType>();
            CreateMap<CommandMWOType, AddMWOType>();
        }
    }
}
