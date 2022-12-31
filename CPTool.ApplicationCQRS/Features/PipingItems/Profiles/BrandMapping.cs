global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.PipingItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PipingItems.Profiles
{
    internal class PipingItemMapping : Profile
    {
        public PipingItemMapping()
        {
            CreateMap<PipingItem, CommandPipingItem>();
            CreateMap<CommandPipingItem, PipingItem>();
            CreateMap<AddPipingItem, PipingItem>();
            CreateMap<CommandPipingItem, AddPipingItem>();
            CreateMap<CommandPipingItem, UpdatePipingItem>();
            CreateMap<UpdatePipingItem, PipingItem>();
        }
    }
}
