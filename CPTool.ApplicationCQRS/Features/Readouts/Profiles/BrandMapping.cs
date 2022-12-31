global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Readouts.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Readouts.Profiles
{
    internal class ReadoutMapping : Profile
    {
        public ReadoutMapping()
        {
            CreateMap<Readout, CommandReadout>();
            CreateMap<CommandReadout, Readout>();
            CreateMap<AddReadout, Readout>();
            CreateMap<CommandReadout, AddReadout>();
        }
    }
}
