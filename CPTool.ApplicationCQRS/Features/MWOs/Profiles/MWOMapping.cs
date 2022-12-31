global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.MWOs.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.MWOs.Profiles
{
    internal class MWOMapping : Profile
    {
        public MWOMapping()
        {
            CreateMap<MWO, CommandMWO>();
            CreateMap<CommandMWO, MWO>();
            CreateMap<AddMWO, MWO>();
            CreateMap<CommandMWO, AddMWO>();
        }
    }
}
