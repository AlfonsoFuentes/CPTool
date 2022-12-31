global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.AlterationItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.AlterationItems.Profiles
{
    internal class AlterationItemMapping : Profile
    {
        public AlterationItemMapping()
        {
            CreateMap<AlterationItem, CommandAlterationItem>();
            CreateMap<CommandAlterationItem, AlterationItem>();
            CreateMap<AddAlterationItem, AlterationItem>();
            CreateMap<CommandAlterationItem, AddAlterationItem>();
        }
    }
}
