global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.Gaskets.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.Gaskets.Profiles
{
    internal class GasketMapping : Profile
    {
        public GasketMapping()
        {
            CreateMap<Gasket, CommandGasket>();
            CreateMap<CommandGasket, Gasket>();
            CreateMap<AddGasket, Gasket>();
            CreateMap<CommandGasket, AddGasket>();
        }
    }
}
