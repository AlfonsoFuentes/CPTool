global using CPTool.Domain.Entities;
using AutoMapper;
using CPTool.ApplicationCQRS.Features.SignalTypes.Commands.CreateUpdate;

namespace CPTool.ApplicationCQRS.Features.SignalTypes.Profiles
{
    internal class SignalTypeMapping : Profile
    {
        public SignalTypeMapping()
        {
            CreateMap<SignalType, CommandSignalType>();
            CreateMap<CommandSignalType, SignalType>();
            CreateMap<AddSignalType, SignalType>();
            CreateMap<CommandSignalType, AddSignalType>();
        }
    }
}
