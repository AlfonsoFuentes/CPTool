global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.ControlLoops.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.ControlLoops.Profiles
{
    internal class ControlLoopMapping : Profile
    {
        public ControlLoopMapping()
        {
            CreateMap<ControlLoop, CommandControlLoop>();
            CreateMap<CommandControlLoop, ControlLoop>();
            CreateMap<AddControlLoop, ControlLoop>();
            CreateMap<CommandControlLoop, AddControlLoop>();
        }
    }
}
