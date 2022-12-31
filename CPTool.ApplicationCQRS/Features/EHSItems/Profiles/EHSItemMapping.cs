global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.EHSItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.EHSItems.Profiles
{
    internal class EHSItemMapping : Profile
    {
        public EHSItemMapping()
        {
            CreateMap<EHSItem, CommandEHSItem>();
            CreateMap<CommandEHSItem, EHSItem>();
            CreateMap<AddEHSItem, EHSItem>();
            CreateMap<CommandEHSItem, AddEHSItem>();
        }
    }
}
