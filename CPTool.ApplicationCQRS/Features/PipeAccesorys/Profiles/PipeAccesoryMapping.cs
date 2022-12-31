global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.PipeAccesorys.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PipeAccesorys.Profiles
{
    internal class PipeAccesoryMapping : Profile
    {
        public PipeAccesoryMapping()
        {
            CreateMap<PipeAccesory, CommandPipeAccesory>();
            CreateMap<CommandPipeAccesory, PipeAccesory>();
            CreateMap<AddPipeAccesory, PipeAccesory>();
            CreateMap<CommandPipeAccesory, AddPipeAccesory>();
            CreateMap<CommandPipeAccesory, UpdatePipeAccesory>();
            CreateMap<UpdatePipeAccesory, PipeAccesory>();
        }
    }
}
