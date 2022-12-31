global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.PipeDiameters.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.PipeDiameters.Profiles
{
    internal class PipeDiameterMapping : Profile
    {
        public PipeDiameterMapping()
        {
            CreateMap<PipeDiameter, CommandPipeDiameter>();
            CreateMap<CommandPipeDiameter, PipeDiameter>();
            CreateMap<AddPipeDiameter, PipeDiameter>();
            CreateMap<CommandPipeDiameter, AddPipeDiameter>();
        }
    }
}
