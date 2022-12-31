global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.ConnectionTypes.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.ConnectionTypes.Profiles
{
    internal class ConnectionTypeMapping : Profile
    {
        public ConnectionTypeMapping()
        {
            CreateMap<ConnectionType, CommandConnectionType>();
            CreateMap<CommandConnectionType, ConnectionType>();
            CreateMap<AddConnectionType, ConnectionType>();
            CreateMap<CommandConnectionType, AddConnectionType>();
        }
    }
}
