global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.ElectricalItems.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.ElectricalItems.Profiles
{
    internal class ElectricalItemMapping : Profile
    {
        public ElectricalItemMapping()
        {
            CreateMap<ElectricalItem, CommandElectricalItem>();
            CreateMap<CommandElectricalItem, ElectricalItem>();
            CreateMap<AddElectricalItem, ElectricalItem>();
            CreateMap<CommandElectricalItem, AddElectricalItem>();
        }
    }
}
