global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Nozzles.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Nozzles.Profiles
{
    internal class NozzleMapping : Profile
    {
        public NozzleMapping()
        {
            CreateMap<Nozzle, CommandNozzle>();
            CreateMap<CommandNozzle, Nozzle>();
            CreateMap<AddNozzle, Nozzle>();
            CreateMap<CommandNozzle, AddNozzle>();
        }
    }
}
