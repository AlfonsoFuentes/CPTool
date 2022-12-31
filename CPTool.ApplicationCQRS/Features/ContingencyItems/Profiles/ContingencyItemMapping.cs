global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.ContingencyItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.ContingencyItems.Profiles
{
    internal class ContingencyItemMapping : Profile
    {
        public ContingencyItemMapping()
        {
            CreateMap<ContingencyItem, CommandContingencyItem>();
            CreateMap<CommandContingencyItem, ContingencyItem>();
            CreateMap<AddContingencyItem, ContingencyItem>();
            CreateMap<CommandContingencyItem, AddContingencyItem>();
        }
    }
}
