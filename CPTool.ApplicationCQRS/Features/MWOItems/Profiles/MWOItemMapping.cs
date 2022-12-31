global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.MWOItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.MWOItems.Profiles
{
    internal class MWOItemMapping : Profile
    {
        public MWOItemMapping()
        {
            CreateMap<MWOItem, CommandMWOItem>();
            CreateMap<CommandMWOItem, MWOItem>();
            CreateMap<AddMWOItem, MWOItem>();
            CreateMap<CommandMWOItem, AddMWOItem>();
            CreateMap<CommandMWOItem, UpdateMWOItem>();
            CreateMap<UpdateMWOItem, MWOItem>();
        }
    }
}
