global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.ElectricalBoxs.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.ElectricalBoxs.Profiles
{
    internal class ElectricalBoxMapping : Profile
    {
        public ElectricalBoxMapping()
        {
            CreateMap<ElectricalBox, CommandElectricalBox>();
            CreateMap<CommandElectricalBox, ElectricalBox>();
            CreateMap<AddElectricalBox, ElectricalBox>();
            CreateMap<CommandElectricalBox, AddElectricalBox>();
        }
    }
}
