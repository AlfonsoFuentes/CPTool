global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.FoundationItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.FoundationItems.Profiles
{
    internal class FoundationItemMapping : Profile
    {
        public FoundationItemMapping()
        {
            CreateMap<FoundationItem, CommandFoundationItem>();
            CreateMap<CommandFoundationItem, FoundationItem>();
            CreateMap<AddFoundationItem, FoundationItem>();
            CreateMap<CommandFoundationItem, AddFoundationItem>();
        }
    }
}
