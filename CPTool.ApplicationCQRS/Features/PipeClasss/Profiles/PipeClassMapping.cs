global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.PipeClasss.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PipeClasss.Profiles
{
    internal class PipeClassMapping : Profile
    {
        public PipeClassMapping()
        {
            CreateMap<PipeClass, CommandPipeClass>();
            CreateMap<CommandPipeClass, PipeClass>();
            CreateMap<AddPipeClass, PipeClass>();
            CreateMap<CommandPipeClass, AddPipeClass>();
        }
    }
}
