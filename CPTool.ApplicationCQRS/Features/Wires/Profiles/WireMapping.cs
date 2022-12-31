global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Wires.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Wires.Profiles
{
    internal class WireMapping : Profile
    {
        public WireMapping()
        {
            CreateMap<Wire, CommandWire>();
            CreateMap<CommandWire, Wire>();
            CreateMap<AddWire, Wire>();
            CreateMap<CommandWire, AddWire>();
        }
    }
}
